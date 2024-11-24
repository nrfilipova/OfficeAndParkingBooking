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
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(x => x.Employees.FullName))
                .ReverseMap();

            CreateMap<OfficeBookingInputModel, OfficeBooking>()
                .ForPath(dest => dest.Room.Number, opt => opt.MapFrom(x => x.RoomNumber))
                .ForPath(dest => dest.Employees.Team.Name, opt => opt.MapFrom(x => x.EmployeeTeam))
                .ForPath(dest => dest.Employees.FullName, opt => opt.MapFrom(x => x.EmployeeName))
                .ReverseMap();
        }
    }
}
