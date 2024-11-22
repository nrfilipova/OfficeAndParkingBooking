namespace OfficeAndParkingBooking.Data.Seeding
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        private IEnumerable<Team> teams =
        [
            new Team
            {
                Id = 1,
                Name = "BA",
            },
            new Team
            {
                Id = 2,
                Name = "HR",
            },
            new Team
            {
                Id = 3,
                Name = "Sys Admin",
            },
            new Team
            {
                Id = 4,
                Name = "DevOps",
            },
            new Team
            {
                Id = 5,
                Name = "Java",
            },
            new Team
            {
                Id = 6,
                Name = ".NET",
            },new Team
            {
                Id = 7,
                Name = "AM",
            },
            new Team
            {
                Id = 8,
                Name = "FO",
            }
        ];

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(teams);
        }
    }
}