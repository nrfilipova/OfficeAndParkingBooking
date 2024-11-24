using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficeAndParkingBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarRegistrationPlateConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE Cars
                ADD CONSTRAINT UC_RegistrationPlate UNIQUE (RegistrationPlate);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE Cars
                DROP CONSTRAINT UC_RegistrationPlate;");
        }
    }
}
