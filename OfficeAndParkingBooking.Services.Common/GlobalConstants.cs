namespace OfficeAndParkingBooking.Services.Common
{
    public class GlobalConstants
    {
        public static class CarConstants
        {
            public const int CarRegistrationPlateMinLenght = 7;
            public const int CarRegistrationPlateMaxLenght = 8;
            public const string CarRegistrationPlatePattern = @"^[A-Z]{1,2}[\d]{4}[A-Z]{2}$";
        }

        public static class ParkingSpotConstants
        {
            public const int ParkingSpotStartId = 1;
            public const int ParkingSpotEndId = 4;
        }

        public static class TeamConstants
        {
            public const int TeamNameMinLenght = 2;
            public const int TeamNameMaxLenght = 100;
        }

        public static class EmployeeConstants
        {
            public const int EmployeeNameMinLenght = 2;
            public const int EmployeeNameMaxLenght = 300;
        }

        public static class ErrorMessage
        {
            public const string RequiredErrorMessage = "The {0} field is required";
            public const string LenghtOrRangeErrorMessage = "The {0} field must be between {2} and {1} characters";
            public const string DepartureDateTimeErrorMessage = "Departure cannot be before Arrival";
        }
    }
}