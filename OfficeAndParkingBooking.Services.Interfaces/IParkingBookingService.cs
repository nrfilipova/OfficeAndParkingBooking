namespace OfficeAndParkingBooking.Services.Interfaces
{
    using DTOs;

    public interface IParkingBookingService
    {
        Task AddBookingAsync(ParkingBookingInputModel model, string id);
        Task<IEnumerable<ParkingBookingAllModel>> GetParkingBookingBookingsAsync();
    }
}