using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;


namespace DogSitter.BLL.Configs
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Sitter, SitterModel>().ReverseMap();
            CreateMap<Comment, CommentModel>().ReverseMap();
            CreateMap<Serviсe, ServiceModel>().ReverseMap();
            CreateMap<Timesheet, TimesheetModel>()
                .ForPath(dest => dest.TimeRange.Start, act => act.MapFrom(src => src.Start))
                .ForPath(dest => dest.TimeRange.End, act => act.MapFrom(src => src.End))
                .ReverseMap();
            CreateMap<BusyTime, BusyTimeModel>()
                .ForPath(dest => dest.TimeRange.Start, act => act.MapFrom(src => src.Start))
                .ForPath(dest => dest.TimeRange.End, act => act.MapFrom(src => src.End))
                .ReverseMap();
            CreateMap<Admin, AdminModel>().ReverseMap();
            CreateMap<Contact, ContactModel>().ReverseMap();
            CreateMap<Dog, DogModel>().ReverseMap();
            CreateMap<Passport, PassportModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<SubwayStation, SubwayStationModel>().ReverseMap();
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<DateTime, TimeOnly>()
                .ForMember(m => m.Hour, opt => opt.MapFrom(o => o.Hour))
                .ForMember(m => m.Minute, opt => opt.MapFrom(o => o.Minute))
                .ForMember(m => m.Second, opt => opt.MapFrom(o => o.Second));

            CreateMap<TimeOnly, DateTime>()
                .ForMember(m => m.Hour, opt => opt.MapFrom(o => o.Hour))
                .ForMember(m => m.Minute, opt => opt.MapFrom(o => o.Minute))
                .ForMember(m => m.Second, opt => opt.MapFrom(o => o.Second));
        }

    }
}
