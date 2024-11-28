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
                .ReverseMap();

            CreateMap<ParkingBookingAllModel, ParkingBooking>()
                .ForPath(dest => dest.Employees.FullName, opt => opt.MapFrom(x => x.EmployeeName))
                .ForPath(dest => dest.ParkingSpot.Number, opt => opt.MapFrom(x => x.ParkingSpotNumber))
                .ReverseMap();

            CreateMap<OfficeBookingInputModel, OfficeBooking>();

            CreateMap<RoomModel, Room>().ReverseMap();
            CreateMap<ParkingSpotsModel, ParkingSpot>().ReverseMap();

            CreateMap<OfficeBookingAllModel, OfficeBooking>()
                .ForPath(dest => dest.Employees.FullName, opt => opt.MapFrom(x => x.EmployeeName))
                .ForPath(dest => dest.Employees.Team.Name, opt => opt.MapFrom(x => x.EmployeeTeam))
                .ForPath(dest => dest.Room.Number, opt => opt.MapFrom(x => x.RoomNumber))
               .ReverseMap();
            
            CreateMap<RegisterInputModel, Employee>()
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}