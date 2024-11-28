
namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using DTOs;
    using Services.Interfaces;

    using AutoMapper;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class CarService : ICarService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CarService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<string?> GetCarModels(string id)
        {
            return _repository.AllAsQueryable<Employee>(x => x.Id == id, false)
                .Include(x => x.Cars)
                .SelectMany(x => x.Cars.Select(x => x.Model))
                .ToList();
        }

        public IEnumerable<string> GetRegistrationPlates(string id)
        {
            return _repository.AllAsQueryable<Employee>(x => x.Id == id, false)
                .Include(x => x.Cars)
                .SelectMany(x => x.Cars.Select(x => x.RegistrationPlate))
                .ToList();
        }

        public async Task<IEnumerable<ParkingSpotsModel>> GetSpots()
        {
            var spots = await _repository.AllAsync<ParkingSpot>(null, false);
            return _mapper.Map<IEnumerable<ParkingSpotsModel>>(spots);
        }
    }
}
