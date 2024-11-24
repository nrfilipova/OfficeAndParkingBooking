namespace OfficeAndParkingBooking.Services.Interfaces
{
    public interface IRoomService
    {
        int GetRoomId(int roomNumber);
        int GetRoomCapacity(int roomId);
    }
}
