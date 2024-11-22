namespace OfficeAndParkingBooking.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Room
    {
        [Key]
        public int Id { get; set; }
        public required int Number { get; set; }
        public required int Capacity { get; set; }
        ICollection<OfficeBooking> Bookings { get; set; } = new List<OfficeBooking>();
    }
}
