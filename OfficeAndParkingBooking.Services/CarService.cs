namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using DTOs;
    using Services.Interfaces;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class CarService : ICarService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CarService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DropDownModel>> GetRegistrationPlatesAsync(string id)
        {
            var plates = await _repository
                .AllAsQueryable<Car>(x => x.EmployeeId == id, false)
                .ToListAsync();

            return _mapper.Map<IEnumerable<DropDownModel>>(plates);
        }

        public async Task<IEnumerable<ParkingSpotsModel>> GetParkingSpotsAsync()
        {
            var spots = await _repository.AllAsync<ParkingSpot>(null, false);
            return _mapper.Map<IEnumerable<ParkingSpotsModel>>(spots);
        }
    }
}
