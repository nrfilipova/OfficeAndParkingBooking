namespace OfficeAndParkingBooking.Server.Controllers
{
    using AutoMapper;
    using Data.Models;
    using DTOs;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/identity/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;

        public EmployeeController(UserManager<Employee> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterInputModel model)
        {
            var user = _mapper.Map<Employee>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) 
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }
    }
}