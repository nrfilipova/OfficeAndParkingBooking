namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using DTOs;
    using Interfaces;

    using AutoMapper;
    using System;
    using Microsoft.EntityFrameworkCore;

    public class ParkingBookingService : IParkingBookingService
    {
        private readonly IRepository _repository;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public ParkingBookingService(IRepository repository, IEmployeeService employeeService, IMapper mapper)
        {
            _repository = repository;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        //add reserve spot for a period of time

        public async Task AddBookingAsync(ParkingBookingInputModel model)
        {
            var booking = _mapper.Map<ParkingBooking>(model);
            var isAvailable = ParkingSpotAvailable(model.ParkingSpotId, model.Arrival);
            var employee = _employeeService.GetAllByName(model.EmployeeName);

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

            var cars = await employee
                .Include(x => x.Cars)
                .SelectMany(x => x.Cars)
                .ToListAsync();

            //move the logic to employee and car service

            if (!cars.Any(x => x.RegistrationPlate == model.RegistrationPlate))
            {
                //TODO
                throw new Exception();
            }

            if (!employee.Any(x => x.FullName == model.EmployeeName) && !cars.Any(x => x.RegistrationPlate == model.RegistrationPlate))
            {

                //TODO
                throw new Exception();
            }

            if (model.Departure.CompareTo(model.Arrival) <= 0) 
            {
                throw new Exception();
            }           

            if (isAvailable && employee is null)
            {
                await _repository.AddAsync(booking);
                await _repository.SaveChangesAsync();
            }
            else
            {
                //TODO
                throw new Exception();
            }
        }

        private bool ParkingSpotAvailable(int parkingSpotId, DateTime arrival)
        {
            //add extentions for the time

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
