namespace OfficeAndParkingBooking.Services.Common
{
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DateTimeValidator : ValidationAttribute
    {
        private readonly string _arrival;

        public DateTimeValidator(string arrival)
        {
            _arrival = arrival;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var arrival = DateTime.Now;
            var departure = DateTime.Now;
            var arrivalProp = validationContext.ObjectType.GetProperty(_arrival);

            if (value == null || arrivalProp == null)
            {
                return new ValidationResult("Arrival and departure dates are required");
            }

            var arrivalValue = arrivalProp.GetValue(validationContext.ObjectInstance);

            if (!DateTime.TryParse(value.ToString(), out departure) ||
                !DateTime.TryParse(arrivalValue?.ToString(), out arrival))
            {
                return new ValidationResult("Invalid date format");
            }

            if (departure.CompareTo(arrival) <= 0)
            {
                return new ValidationResult("Departure cannot be before arrival");
            }

            return ValidationResult.Success;
        }
    }
}