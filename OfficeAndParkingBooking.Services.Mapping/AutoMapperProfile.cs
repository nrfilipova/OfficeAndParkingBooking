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

            CreateMap<OfficeBookingInputModel, OfficeBooking>()
                .ReverseMap();


            CreateMap<RegisterInputModel, Employee>()
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}