namespace OfficeAndParkingBooking.Data.Models
{
    using static Services.Common.GlobalConstants.TeamConstants;

    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        [Key]
        public int Id { get; set; }

        [StringLength(TeamNameMaxLenght)]
        public required string Name { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
