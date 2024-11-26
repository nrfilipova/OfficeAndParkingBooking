namespace OfficeAndParkingBooking.Services.Interfaces
{
    using Data.Models;
    using DTOs;

    public interface IOfficeBookingService
    {
        Task AddBookingAsync(OfficeBookingInputModel model);
        Task<IEnumerable<OfficeBooking>> GetOfficeBookingsAsync();
    }
}