namespace OfficeAndParkingBooking.Services.Common
{
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ParkingTime : ValidationAttribute
    {
        private readonly string _arrival;

        public ParkingTime(string arrival)
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

            var endOfDay = new TimeSpan(23, 59, 59);

            if (departure < arrival.AddMinutes(15))
            {
                return new ValidationResult("Departure must be at lest 15 min after arrival");
            }

            if (departure.TimeOfDay > endOfDay)
            {
                return new ValidationResult("Departure must be the same day");
            }

            return ValidationResult.Success;
        }
    }
}