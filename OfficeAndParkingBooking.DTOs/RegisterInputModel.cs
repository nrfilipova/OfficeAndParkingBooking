namespace OfficeAndParkingBooking.DTOs
{
    using static Services.Common.GlobalConstants.EmployeeConstants;
    using static Services.Common.GlobalConstants.ErrorMessage;

    using System.ComponentModel.DataAnnotations;

    public class RegisterInputModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(EmployeeNameMaxLenght, MinimumLength = EmployeeNameMinLenght, ErrorMessage = RequiredErrorMessage)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string TeamName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Password { get; set; } = string.Empty;
    }
}