namespace OfficeAndParkingBooking.Services.Interfaces
{
    using DTOs;

    public interface ITeamService
    {
        Task<IEnumerable<DropDownModel>> GetTeamsAsync();
    }
}
