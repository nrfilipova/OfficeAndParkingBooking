namespace OfficeAndParkingBooking.Services.Interfaces
{
    using DTOs;

    public interface IOfficeBookingService
    {
        Task AddBookingAsync(OfficeBookingInputModel model, string id);
        Task<IEnumerable<OfficeBookingAllModel>> GetOfficeBookingsAsync();
        Task<IEnumerable<RoomModel>> GetRoomsAsync();
    }
}