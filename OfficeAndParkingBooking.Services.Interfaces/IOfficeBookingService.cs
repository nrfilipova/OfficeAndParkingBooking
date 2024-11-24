namespace OfficeAndParkingBooking.Services.Interfaces
{
    using DTOs;

    public interface IOfficeBookingService
    {
        Task AddBookingAsync(OfficeBookingInputModel model);

        int GetBookingCount(int roomId, DateTime date);
    }
}
