using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficeAndParkingBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeNameIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE INDEX idx_fullName 
                ON Employees (FullName);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP INDEX Employees.idx_fullName;");
        }
    }
}
