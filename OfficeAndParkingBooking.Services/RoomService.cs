namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using Interfaces;

    public class RoomService : IRoomService
    {
        private readonly IRepository _repository;

        public RoomService(IRepository repository)
        {
            _repository = repository;
        }

        public int GetRoomCapacity(int roomId)
        {
           return _repository.AllAsQueryable<Room>(x => x.Id == roomId)
                .Select(x => x.Capacity)
                .FirstOrDefault();
        }

        public int GetRoomId(int roomNumber)
        {
            return _repository.AllAsQueryable<Room>(x => x.Number == roomNumber)
                .Select(x => x.Id)
                .FirstOrDefault();
        }
    }
}
