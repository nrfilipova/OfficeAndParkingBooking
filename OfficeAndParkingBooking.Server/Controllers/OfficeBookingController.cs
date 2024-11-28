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
    public class OfficeBookingController : ControllerBase
    {
        private readonly ILogger<ParkingBookingController> _logger;
        private readonly IOfficeBookingService _officeBookingService;

        public OfficeBookingController(ILogger<ParkingBookingController> logger, IOfficeBookingService officeBookingService)
        {
            _logger = logger;
            _officeBookingService = officeBookingService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<OfficeBookingAllModel> GetAllOfficeBooking()
        {
            return _officeBookingService.GetOfficeBookings();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/GetAllRooms")]
        public async Task<IEnumerable<RoomModel>> GetAllRooms()
        {
            return await _officeBookingService.GetRooms();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOfficeBooking([FromBody] OfficeBookingInputModel model)
        {
            try
            {
                string userId = User.Id();
                await _officeBookingService.AddBookingAsync(model, userId);
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