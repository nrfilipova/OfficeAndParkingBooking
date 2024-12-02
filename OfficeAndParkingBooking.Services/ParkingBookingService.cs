namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using DTOs;
    using Interfaces;
    using Services.Common.Exceptions;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.Logging;

    public class ParkingBookingService : IParkingBookingService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ParkingBookingService> _logger;

        public ParkingBookingService(IRepository repository, IMapper mapper, ILogger<ParkingBookingService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
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

            var bookings = await _repository.AllAsQueryable<ParkingBooking>(x => x.Arrival.Day == model.Arrival.Day, false)
                .Include(x => x.Employees)
                .ThenInclude(x => x.Cars)
                .Select(x => x.Employees.Cars.Where(x => x.RegistrationPlate == model.RegistrationPlate))
                .FirstOrDefaultAsync();

            if (!isAvailable)
            {
                _logger.LogError($"ParkingBookingService/AddBookingAsync: Spot with id - {model.SpotId} is not available for arrival - {model.Arrival}, departure: {model.Departure}");
                throw new ParkingSpotNotAvailableException();
            }

            if (booking != null)
            {
                _logger.LogError($"ParkingBookingService/AddBookingAsync: Allready booked for this car {model.RegistrationPlate}.");
                throw new InvalidOperationException();
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