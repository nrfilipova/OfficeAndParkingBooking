namespace OfficeAndParkingBooking.Services.Mapping
{
    using Data.Models;
    using DTOs;

    using AutoMapper;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ParkingBooking, ParkingBookingInputModel>()
                .ForPath(dest => dest.SpotId, opt => opt.MapFrom(x => x.ParkingSpotId))
                .ReverseMap();

            CreateMap<ParkingBookingAllModel, ParkingBooking>()
                .ForPath(dest => dest.Employees.FullName, opt => opt.MapFrom(x => x.EmployeeName))
                .ForPath(dest => dest.ParkingSpot.Number, opt => opt.MapFrom(x => x.ParkingSpotNumber))
                .ReverseMap();

            CreateMap<ParkingSpotsModel, ParkingSpot>().ReverseMap();

            CreateMap<OfficeBookingInputModel, OfficeBooking>();

            CreateMap<OfficeBookingAllModel, OfficeBooking>()
                .ForPath(dest => dest.Employees.FullName, opt => opt.MapFrom(x => x.EmployeeName))
                .ForPath(dest => dest.Employees.Team.Name, opt => opt.MapFrom(x => x.EmployeeTeam))
                .ForPath(dest => dest.Room.Number, opt => opt.MapFrom(x => x.RoomNumber))
               .ReverseMap();

            CreateMap<RoomModel, Room>().ReverseMap();

            CreateMap<CarModel, Car>()
                 .ForPath(dest => dest.RegistrationPlate, opt => opt.MapFrom(x => x.Name))
                 .ForPath(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<RegisterInputModel, Employee>()
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}