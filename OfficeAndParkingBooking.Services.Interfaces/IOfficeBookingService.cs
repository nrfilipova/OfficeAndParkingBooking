namespace OfficeAndParkingBooking.Services.Interfaces
{
    using DTOs;

    public interface IOfficeBookingService
    {
        Task AddBookingAsync(OfficeBookingInputModel model, string id);
        IEnumerable<OfficeBookingAllModel> GetOfficeBookings();
        Task<IEnumerable<RoomModel>> GetRooms();
    }
}