namespace OfficeAndParkingBooking.Server.Controllers
{
    using OfficeAndParkingBooking.DTOs;
    using OfficeAndParkingBooking.Services.Interfaces;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ParkingBookingController : ControllerBase
    {
        private readonly ILogger<ParkingBookingController> _logger;
        private readonly IParkingBookingService _parkingService;

        public ParkingBookingController(ILogger<ParkingBookingController> logger, IParkingBookingService carService)
        {
            _logger = logger;
            _parkingService = carService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateParkingBooking(ParkingBookingInputModel model)
        {
            if (!ModelState.IsValid)
            {
                //TODO log error
                return BadRequest(ModelState);
            }

            try
            {
                await _parkingService.AddBookingAsync(model);
            }
            catch (Exception)
            {
                //add log and write error
                return BadRequest();
            }

            return Ok();
        }
    }
}
