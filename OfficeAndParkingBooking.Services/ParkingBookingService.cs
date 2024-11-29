namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using DTOs;
    using Interfaces;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System;
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

        public async Task<IEnumerable<ParkingBookingAllModel>> GetParkingBookingBookingsAsync()
        {
            var bookings = await _repository.AllAsQueryable<ParkingBooking>(null, false)
                .Include(x => x.Employees)
                .Include(x => x.ParkingSpot)
                .OrderBy(x => x.Departure)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ParkingBookingAllModel>>(bookings);
        }

        public async Task AddBookingAsync(ParkingBookingInputModel model, string id)
        {
            var booking = _mapper.Map<ParkingBooking>(model);
            booking.EmployeeId = id;
            var isAvailable = ParkingSpotAvailable(model.SpotId, model.Arrival);
            //var carToBook = await _repository.AllAsQueryable<Car>(x => x.Id == model.RegistrationPlateId, false).Select(x => x.RegistrationPlate).FirstOrDefaultAsync();
            //var empCarsIds = await _repository.AllAsQueryable<Employee>(x => x.Id == model.EmployeeId, false).Include(x => x.Cars).SelectMany(x => x.Cars.Select(x => x.Id)).ToListAsync();

            if (booking == null)
            {
                //TODO
                throw new AutoMapperMappingException();
            }

            if (model.Departure.CompareTo(model.Arrival) <= 0)
            {
                throw new Exception();
            }

            if (!isAvailable)
            {
                //TODO sorry its not available
            }

            //if (!empCarsIds.Contains(carToBook.Id))
            //{
            //    //TODO
            //    throw new Exception();
            //}

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