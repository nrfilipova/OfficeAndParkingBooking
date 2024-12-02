namespace OfficeAndParkingBooking.Services
{
    using Data.Models;
    using DTOs;
    using Services.Interfaces;

    using AutoMapper;

    public class TeamService : ITeamService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public TeamService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DropDownModel>> GetTeamsAsync()
        {
            var teams = await _repository.AllAsync<Team>(null, false);
            return _mapper.Map<IEnumerable<DropDownModel>>(teams);
        }
    }
}
