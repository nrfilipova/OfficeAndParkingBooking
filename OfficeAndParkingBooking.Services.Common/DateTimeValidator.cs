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
                //TODO add error
                return new ValidationResult("");
            }

            var arrivalValue = arrivalProp.GetValue(validationContext.ObjectInstance);

            if (!DateTime.TryParse(value.ToString(), out departure) ||
                !DateTime.TryParse(arrivalValue?.ToString(), out arrival))
            {
                //TODO add error
                return new ValidationResult("");
            }

            if (departure.CompareTo(arrival) <= 0)
            {
                //TODO add error
                return new ValidationResult("");
            }

            return ValidationResult.Success;
        }
    }
}