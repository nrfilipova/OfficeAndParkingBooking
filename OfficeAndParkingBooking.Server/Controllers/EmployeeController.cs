namespace OfficeAndParkingBooking.Server.Controllers
{
    using AutoMapper;
    using Data.Models;
    using DTOs;
    using Services.Interfaces;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/identity/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public EmployeeController(UserManager<Employee> userManager, IMapper mapper, IRepository repository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterInputModel model)
        {
            var teamId = _repository.AllAsQueryable<Team>(x => x.Name == model.TeamName).Select(x => x.Id).FirstOrDefault();
            var user = _mapper.Map<Employee>(model);

            user.TeamId = teamId;

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) 
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }
    }
}