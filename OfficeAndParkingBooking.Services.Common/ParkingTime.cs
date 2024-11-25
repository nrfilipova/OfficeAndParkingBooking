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

            var endOfDay = new TimeSpan(23, 59, 59);

            if (departure < arrival.AddMinutes(15))
            {
                //TODO add error
                return new ValidationResult("");
            }

            if (departure.TimeOfDay > endOfDay)
            {
                //TODO add error
                return new ValidationResult("");
            }

            return ValidationResult.Success;
        }
    }
}