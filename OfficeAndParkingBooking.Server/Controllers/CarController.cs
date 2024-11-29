namespace OfficeAndParkingBooking.Server.Controllers
{
    using Services.Common;
    using Services.Interfaces;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("car")]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Route("/spots")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCarSpots()
        {
            return Ok(await _carService.GetParkingSpotsAsync());
        }

        [HttpGet]
        [Route("/registrationPlates")]
        public async Task<IActionResult> GetCarRegistrationPlates()
        {
            string userId = User.Id();
            return Ok(await _carService.GetRegistrationPlatesAsync(userId));
        }
    }
}
