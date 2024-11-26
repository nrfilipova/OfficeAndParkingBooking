﻿namespace OfficeAndParkingBooking.Server.Controllers
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
        public IEnumerable<OfficeBookingAllModel> GetAllEmployees()
        {
            return _officeBookingService.GetOfficeBookings();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOfficeBooking(OfficeBookingInputModel model)
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
                await _officeBookingService.AddBookingAsync(model);
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