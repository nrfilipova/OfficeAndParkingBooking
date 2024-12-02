namespace OfficeAndParkingBooking.Services.Common.Validators
{
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DateValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateOnly date)
            {
                if (date.Day >= DateOnly.FromDateTime(DateTime.Now).Day &&
                    date.Month == DateOnly.FromDateTime(DateTime.Now).Month &&
                    date.Year == DateOnly.FromDateTime(DateTime.Now).Year)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage ?? "Wrong date format");
        }
    }
}