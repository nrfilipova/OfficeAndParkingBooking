namespace OfficeAndParkingBooking.Services.Common
{
    using System.Security.Claims;

    public static class ClaimsPrincipalExtention
    {
        public static string Id(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
    }
}
