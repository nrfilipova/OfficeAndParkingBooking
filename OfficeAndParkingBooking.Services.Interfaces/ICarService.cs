namespace OfficeAndParkingBooking.Services.Interfaces
{
    using DTOs;

    public interface ICarService
    {
        Task<IEnumerable<ParkingSpotsModel>> GetParkingSpotsAsync();
        Task<IEnumerable<DropDownModel>> GetRegistrationPlatesAsync(string id);
    }
}
