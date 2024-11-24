namespace OfficeAndParkingBooking.Services.Interfaces
{
    using Data.Models;

    public interface IEmployeeService
    {
        IQueryable<Employee?> GetAllByName(string fullName);
    }
}
