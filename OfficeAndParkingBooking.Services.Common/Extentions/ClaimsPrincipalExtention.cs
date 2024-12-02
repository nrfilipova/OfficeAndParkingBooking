namespace OfficeAndParkingBooking.Services.Common.Extentions
{
    using System.Security.Claims;

    public static class ClaimsPrincipalExtention
    {
        public static string Id(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
            {
                throw new ArgumentNullException(nameof(claimsPrincipal));
            }

            return claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}