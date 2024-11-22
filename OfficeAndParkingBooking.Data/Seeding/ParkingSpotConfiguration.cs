namespace OfficeAndParkingBooking.Data.Seeding
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ParkingSpotConfiguration : IEntityTypeConfiguration<ParkingSpot>
    {
        private IEnumerable<ParkingSpot> spots =
        [
            new ParkingSpot
            {
                Id = 1,
                Number = 1,
            },
            new ParkingSpot
            {
                Id = 2,
                Number = 2,
            },
            new ParkingSpot
            {
                Id = 3,
                Number = 3,
            },
            new ParkingSpot
            {
                Id = 4,
                Number = 4,
            }
        ];

        public void Configure(EntityTypeBuilder<ParkingSpot> builder)
        {
            builder.HasData(spots);
        }
    }
}