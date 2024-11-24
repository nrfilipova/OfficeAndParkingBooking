﻿namespace OfficeAndParkingBooking.Server.Controllers
{
    using OfficeAndParkingBooking.DTOs;
    using Services.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class OfficeBookingController : ControllerBase
    {
        private readonly ILogger<ParkingBookingController> _logger;
        private readonly IOfficeBookingService _officeBookingService;

        public OfficeBookingController(ILogger<ParkingBookingController> logger, IOfficeBookingService officeBookingService)
        {
            _logger = logger;
            _officeBookingService = officeBookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfficeBooking(OfficeBookingInputModel model)
        {
            if (!ModelState.IsValid)
            {
                //TODO log error
                return BadRequest(ModelState);
            }

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