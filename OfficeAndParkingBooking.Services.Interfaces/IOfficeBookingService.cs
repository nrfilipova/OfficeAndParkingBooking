namespace OfficeAndParkingBooking.Services.Interfaces
{
    using DTOs;

    public interface IOfficeBookingService
    {
        Task AddBookingAsync(OfficeBookingInputModel model);
    }
}