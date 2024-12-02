namespace OfficeAndParkingBooking.Server.Controllers
{
    using DTOs;
    using Services.Interfaces;
    using Services.Common.Extentions;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("parkingBooking")]
    [Authorize]
    public class ParkingBookingController : ControllerBase
    {
        private readonly IParkingBookingService _parkingService;

        public ParkingBookingController(IParkingBookingService carService)
        {
            _parkingService = carService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllEmployeesParkingBookingBookings()
        {
            return Ok(await _parkingService.GetParkingBookingBookingsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateParkingBooking([FromBody] ParkingBookingInputModel model)
        {
            string userId = User.Id();
            await _parkingService.AddBookingAsync(model, userId);

            return Ok();
        }
    }
}