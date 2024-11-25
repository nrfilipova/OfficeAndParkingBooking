namespace OfficeAndParkingBooking.Services.Common
{
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DateValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateOnly date)
            {
                if (date <= DateOnly.FromDateTime(DateTime.UtcNow))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage ?? "Date cannot be in the past");
        }
    }
}