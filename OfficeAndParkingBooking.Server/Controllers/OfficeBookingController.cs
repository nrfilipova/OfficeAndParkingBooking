namespace OfficeAndParkingBooking.Server.Controllers
{
    using DTOs;
    using Services.Interfaces;
    using Services.Common.Extentions;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("officeBooking")]
    [Authorize]
    public class OfficeBookingController : ControllerBase
    {
        private readonly IOfficeBookingService _officeBookingService;

        public OfficeBookingController(IOfficeBookingService officeBookingService)
        {
            _officeBookingService = officeBookingService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllOfficeBooking()
        {
            return Ok(await _officeBookingService.GetOfficeBookingsAsync());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/rooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            return Ok(await _officeBookingService.GetRoomsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfficeBooking([FromBody] OfficeBookingInputModel model)
        {
            string userId = User.Id();
            await _officeBookingService.AddBookingAsync(model, userId);

            return Ok();
        }
    }
}