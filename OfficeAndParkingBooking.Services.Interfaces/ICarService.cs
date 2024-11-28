namespace OfficeAndParkingBooking.Services.Interfaces
{
    using DTOs;

    public interface ICarService
    {
        Task<IEnumerable<ParkingSpotsModel>> GetSpots();
        IEnumerable<string> GetRegistrationPlates(string id);
        IEnumerable<string?> GetCarModels(string id);
    }
}
