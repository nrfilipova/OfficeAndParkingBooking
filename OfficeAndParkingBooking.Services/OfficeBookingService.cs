namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using DTOs;
    using Interfaces;

    using AutoMapper;

    public class OfficeBookingService : IOfficeBookingService
    {
        private readonly IRepository _repository;
        private readonly IEmployeeService _employeeService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public OfficeBookingService(IRepository repository, IEmployeeService employeeService, IRoomService roomService, IMapper mapper)
        {
            _repository = repository;
            _employeeService = employeeService;
            _roomService = roomService;
            _mapper = mapper;
        }

        public async Task AddBookingAsync(OfficeBookingInputModel model)
        {
            var officeBooking = _mapper.Map<OfficeBooking>(model);
            var employees = _employeeService.GetAllByName(model.EmployeeName).ToList();

            //check the emp team if null add it if its changed 

            if (officeBooking == null)
            {
                //TODO
                throw new AutoMapperMappingException();
            }

            if (employees.Count() == 0)
            {
                //TODO
                throw new Exception();
            }

            var roomId = _roomService.GetRoomId(model.RoomNumber);
            var roomCapacity = _roomService.GetRoomCapacity(roomId);
            var bookingsCount = GetBookingCount(roomId, model.Date);

            if (roomId == 0 || bookingsCount + 1 > roomCapacity)
            {
                //TODO
                throw new Exception();
            }

            //add the employee properties
            await _repository.AddAsync(officeBooking);
            await _repository.SaveChangesAsync();

            return;
        }

        public int GetBookingCount(int roomId, DateTime date)
        {
            return _repository.AllAsQueryable<OfficeBooking>(x => x.RoomId == roomId && x.Date == date).Count();
        }
    }
}
