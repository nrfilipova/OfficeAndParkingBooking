namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using DTOs;
    using Interfaces;

    using AutoMapper;
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class ParkingBookingService : IParkingBookingService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ParkingBookingService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ParkingSpotsModel>> GetSpots()
        {
            var spots = await _repository.AllAsync<ParkingSpot>(null, false);
            return _mapper.Map<IEnumerable<ParkingSpotsModel>>(spots);
        }

        public IEnumerable<ParkingBookingAllModel> GetParkingBookingBookings()
        {
            var bookings = _repository.AllAsQueryable<ParkingBooking>(null, false)
                .Include(x => x.Employees)
                .OrderBy(x => x.Departure)
                .ToList();

            return _mapper.Map<IEnumerable<ParkingBookingAllModel>>(bookings);
        }

        public async Task AddBookingAsync(ParkingBookingInputModel model)
        {
            var booking = _mapper.Map<ParkingBooking>(model);
            var isAvailable = ParkingSpotAvailable(model.ParkingSpotId, model.Arrival);
            var employee = await _repository.FindByIdAsync<Employee>(model.EmployeeId);
            var carToBook = await _repository.AllAsQueryable<Car>(x => x.RegistrationPlate == model.RegistrationPlate, false).FirstOrDefaultAsync();
            var empCarsIds = await _repository.AllAsQueryable<Employee>(x => x.Id == model.EmployeeId, false).Include(x => x.Cars).SelectMany(x => x.Cars.Select(x => x.Id)).ToListAsync();

            if (booking == null)
            {
                //TODO
                throw new AutoMapperMappingException();
            }

            if (employee == null)
            {
                //TODO
                throw new Exception();
            }

            if (model.Departure.CompareTo(model.Arrival) <= 0)
            {
                throw new Exception();
            }

            if (!isAvailable)
            {
                //TODO sorry its not available
            }

            if (!empCarsIds.Contains(carToBook.Id))
            {
                //TODO
                throw new Exception();
            }

            await _repository.AddAsync(booking);
            await _repository.SaveChangesAsync();
        }

        private bool ParkingSpotAvailable(int parkingSpotId, DateTime arrival)
        {
            var spot = _repository.AllAsQueryable<ParkingBooking>
                (x => x.ParkingSpotId == parkingSpotId &&
                x.Arrival.Date == arrival.Date)
                .FirstOrDefault();

            if (spot == null)
            {
                return true;
            }

            return spot.Departure.Hour >= arrival.Hour ? false : true;
        }
    }
}