namespace OfficeAndParkingBooking.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OfficeBooking
    {
        [Key]
        public int Id { get; set; }
        public required DateOnly Date { get; set; }
        public string? Notes { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public required string EmployeeId { get; set; }
        public Employee Employees { get; set; } = null!;
    }
}
