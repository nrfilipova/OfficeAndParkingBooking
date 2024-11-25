using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficeAndParkingBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class OfficeBookingDateCheckConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE OfficeBooking
                ADD CONSTRAINT CHK_OfficeBookingDate CHECK (Date >= CAST(GETDATE() AS DATE));");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE OfficeBooking
                DROP CONSTRAINT CHK_OfficeBookingDate;");
        }
    }
}
