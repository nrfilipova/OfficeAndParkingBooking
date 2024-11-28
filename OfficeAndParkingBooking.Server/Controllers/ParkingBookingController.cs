namespace OfficeAndParkingBooking.Server.Controllers
{
    using DTOs;
    using Services.Interfaces;
    using Services.Common;

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

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<ParkingBookingAllModel> GetAllEmployees()
        {
            return _parkingService.GetParkingBookingBookings();
        }

        [HttpPost]
        public async Task<IActionResult> CreateParkingBooking([FromBody] ParkingBookingInputModel model)
        {
            if (!ModelState.IsValid)
            {
                //TODO log error
                return BadRequest(ModelState);
            }

            string userId = User.Id();
            model.EmployeeId = userId;

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