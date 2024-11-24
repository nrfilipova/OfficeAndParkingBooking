namespace OfficeAndParkingBooking.Services.Interfaces
{
    using DTOs;

    public interface IParkingBookingService
    {
        Task AddBookingAsync(ParkingBookingInputModel model);
    }
}
