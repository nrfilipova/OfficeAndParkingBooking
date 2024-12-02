namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using DTOs;
    using Interfaces;
    using Services.Common.Exceptions;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class OfficeBookingService : IOfficeBookingService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<OfficeBookingService> _logger;

        public OfficeBookingService(IRepository repository,IMapper mapper, ILogger<OfficeBookingService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<OfficeBookingAllModel>> GetOfficeBookingsAsync()
        {
            var bookings = await _repository.AllAsQueryable<OfficeBooking>(null, false)
                .Include(x => x.Room)
                .Include(x => x.Employees)
                .ThenInclude(x => x.Team)
                .OrderByDescending(x => x.Date)
                .ToListAsync();

            return _mapper.Map<IEnumerable<OfficeBookingAllModel>>(bookings);
        }

        public async Task<IEnumerable<RoomModel>> GetRoomsAsync()
        {
            var rooms = await _repository.AllAsync<Room>(null, false);
            return _mapper.Map<IEnumerable<RoomModel>>(rooms);
        }

        public async Task AddBookingAsync(OfficeBookingInputModel model, string id)
        {
            var currentBooking = _mapper.Map<OfficeBooking>(model);
            currentBooking.EmployeeId = id;

            var roomCapacity = await _repository
                .AllAsQueryable<Room>(x => x.Id == currentBooking.RoomId, false)
                .Select(x => x.Capacity)
                .FirstOrDefaultAsync();
        
            var bookingsForTheDay = await _repository
                .AllAsQueryable<OfficeBooking>
                    (x => x.RoomId == currentBooking.RoomId && x.Date == currentBooking.Date, false)
                .ToListAsync();

            if (bookingsForTheDay.Any(x => x.EmployeeId == id && x.Date == model.Date))
            {
                _logger.LogError($"OfficeBookingService/AddBookingAsync: User with {id} cant' book twice for the same day - {model.Date}");
                throw new BookingTwiceException();
            }

            if (bookingsForTheDay.Count() + 1 > roomCapacity)
            {
                _logger.LogError($"OfficeBookingService/AddBookingAsync: Room with id - {model.RoomId} capacity {roomCapacity} exceeded");
                throw new CapacityExceededException();
            }

            await _repository.AddAsync(currentBooking);
            await _repository.SaveChangesAsync();
        }
    }
}