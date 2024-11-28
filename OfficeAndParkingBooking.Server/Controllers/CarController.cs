namespace OfficeAndParkingBooking.Server.Controllers
{
    using AutoMapper;
    using DTOs;
    using Services.Common;
    using Services.Interfaces;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;

        public CarController(IMapper mapper, ICarService carService)
        {
            _mapper = mapper;
            _carService = carService;
        }

        [HttpGet]
        [Route("/GetSpots")]
        [AllowAnonymous]
        public async Task<IEnumerable<ParkingSpotsModel>> GetCarSpots()
        {
            return await _carService.GetSpots();
        }

        [HttpGet]
        [Route("/GetRegistrationPlates")]
        [AllowAnonymous]
        public IEnumerable<string> GetCarRegistrationPlates()
        {
            string userId = User.Id();
            return _carService.GetRegistrationPlates("userId");
        }

        [HttpGet]
        [Route("/GetModels")]
        [AllowAnonymous]
        public IEnumerable<string?> GetCarModels()
        {
            string userId = User.Id();
            return _carService.GetCarModels("userId");
        }
    }
}
