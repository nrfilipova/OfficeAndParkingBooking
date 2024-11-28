namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using DTOs;
    using Interfaces;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class OfficeBookingService : IOfficeBookingService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public OfficeBookingService(IRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<OfficeBookingAllModel> GetOfficeBookings()
        {
            var bookings = _repository.AllAsQueryable<OfficeBooking>(null, false)
                .Include(x => x.Room)
                .Include(x => x.Employees)
                .ThenInclude(x => x.Team)
                .OrderByDescending(x => x.Date)
                .ToList();

            return _mapper.Map<IEnumerable<OfficeBookingAllModel>>(bookings);
        }

        public async Task<IEnumerable<RoomModel>> GetRooms()
        {
            var rooms = await _repository.AllAsync<Room>(null, false);
            return _mapper.Map<IEnumerable<RoomModel>>(rooms);
        }

        public async Task AddBookingAsync(OfficeBookingInputModel model, string id)
        {
            var officeBooking = _mapper.Map<OfficeBooking>(model);
            //var employee = _repository.AllAsQueryable<Employee>(x => x.Id == id).Include(x => x.Team).FirstOrDefault();
            //var roomId = _repository.AllAsQueryable<Room>(x => x.Number == model.RoomNumber, false).Select(x => x.Id).FirstOrDefault();
            //var roomCapacity = _repository.AllAsQueryable<Room>(x => x.Id == roomId, false).Select(x => x.Capacity).FirstOrDefault();
            //var bookings = _repository.AllAsQueryable<OfficeBooking>(x => x.RoomId == roomId && x.Date == model.Date, false);

            //if (officeBooking == null)
            //{
            //    //TODO
            //    throw new AutoMapperMappingException();
            //}

            //if (employee == null || roomId == 0)
            //{
            //    //TODO
            //    throw new Exception();
            //}

            //if (bookings.Any(x => x.EmployeeId == id && x.Date == model.Date))
            //{
            //    //TODO
            //    //cant book twice for the same day
            //}

            //officeBooking.Employees = employee;
            //officeBooking.RoomId = roomId;

            //if (roomId == 0 || bookings.Count() + 1 > roomCapacity)
            //{
            //    //TODO
            //    throw new Exception();
            //}

            //await _repository.AddAsync(officeBooking);
            //await _repository.SaveChangesAsync();
        }
    }
}