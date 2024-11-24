namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using Interfaces;

    using AutoMapper;
    using System.Linq;

    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IQueryable<Employee?> GetAllByName(string fullName)
        {
            return _repository.AllAsQueryable<Employee>(x => x.FullName == fullName);
        }
    }
}
