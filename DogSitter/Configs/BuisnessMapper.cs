using AutoMapper;
using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;

namespace DogSitter.API.Configs
{
    public class BuisnessMapper : Profile
    {
        public BuisnessMapper()
        {
            CreateMap<AdminInsertInputModel, AdminModel>();
            CreateMap<AdminUpdateInputModel, AdminModel>();
            CreateMap<AdminModel, AdminOutputModel>().ReverseMap();

            CreateMap<ContactModel, ContactOutputModel>()
            .ForMember(dest => dest.ContactType, act => act.MapFrom(src => src.ContactType));
            CreateMap<ContactInsertInputModel, ContactModel>()
            .ForMember(dest => dest.ContactType, act => act.MapFrom(src => src.ContactType));

            CreateMap<PassportInsertInputModel, PassportModel>();
            CreateMap<PassportUpdateInputModel, PassportModel>();
            CreateMap<PassportModel, PassportOutputModel>();

            CreateMap<SubwayStationModel, SubwayStationOutputModel>();
            CreateMap<SubwayStationInputModel, SubwayStationModel>();
            CreateMap<int, SubwayStationModel>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src));

            CreateMap<AddressModel, AddressOutputModel>();
            CreateMap<AddressInputModel, AddressModel>()
                .ForMember(m => m.SubwayStations, opt => opt.MapFrom(o => o.SubwayStationsId));

            CreateMap<ServiceInsertInputModel, ServiceModel>();
            CreateMap<ServiceUpdateInputModel, ServiceModel>();
            CreateMap<ServiceModel, ServiceOutputModel>();

            CreateMap<SitterInsertInputModel, SitterModel>()
                .ForPath(dest => dest.SubwayStation.Id, opt => opt.MapFrom(srs => srs.SubwayStationId));
            CreateMap<SitterUpdateInputModel, SitterModel>()
                .ForPath(dest => dest.SubwayStation.Id, opt => opt.MapFrom(srs => srs.SubwayStationId));
            CreateMap<SitterModel, SitterOutputModel>();
            CreateMap<SitterModel, SitterForAdminOutputModel>();

            CreateMap<CustomerModel, CustomerOutputModel>();
            CreateMap<CustomerInputModel, CustomerModel>();
            CreateMap<CustomerUpdateInputModel, CustomerModel>();

            CreateMap<DogModel, DogOutputModel>();
            CreateMap<DogUpdateInputModel, DogModel>();

            CreateMap<OrderModel, OrderOutputModel>();
            CreateMap<OrderUpdateCommentAndMarkModel, OrderModel>();
            CreateMap<int, ServiceModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src));
            CreateMap<OrderUpdateInputModel, OrderModel>()
                .ForMember(m => m.Dog, opt => opt.MapFrom(o => new DogModel { Id = o.DogId }))
                .ForMember(m => m.Sitter, opt => opt.MapFrom(o => new SitterModel { Id = o.SitterId }))
                .ForMember(m => m.Services, opt => opt.MapFrom(o => o.ServicesId))
                .ForMember(m => m.SitterBusyTime, opt => opt.MapFrom(o => new BusyTimeModel { Id = o.SitterWorkTimeId }));

            CreateMap<OrderInsertInputModel, OrderOutputModel>();
            CreateMap<OrderInsertInputModel, OrderModel>();

            CreateMap<TimesheetModel, TimesheetOutputModel>();
            CreateMap<TimesheetOutputModel, TimesheetModel>();
            CreateMap<TimesheetOutputModel, TimesheetModel>();
            CreateMap<TimesheetInsertInputModel, TimesheetOutputModel>();
            CreateMap<TimesheetModel, TimesheetInsertInputModel>()
                .ForMember(m => m.Start, opt => opt.MapFrom(o => o.TimeRange.Start))
                .ForMember(m => m.End, opt => opt.MapFrom(o => o.TimeRange.End));
            CreateMap<TimesheetInsertInputModel, TimesheetModel>()
               .ForPath(m => m.TimeRange.Start, opt => opt.MapFrom(o => o.Start))
               .ForPath(m => m.TimeRange.End, opt => opt.MapFrom(o => o.End))
               .ForMember(m => m.Sitter, opt => opt.MapFrom(o => new SitterModel()));

            CreateMap<BusyTimeModel, BusyTimeOutputModel>();
            CreateMap<BusyTimeOutputModel, BusyTimeModel>();
            CreateMap<BusyTimeOutputModel, BusyTimeModel>();
            CreateMap<BusyTimeInsertInputModel, BusyTimeOutputModel>()
                .ForMember(m => m.TimeRange, opt => opt.MapFrom(o => o.Start))
                .ForMember(m => m.TimeRange, opt => opt.MapFrom(o => o.End));
            CreateMap<BusyTimeInsertInputModel, BusyTimeModel>()
                .ForMember(m => m.TimeRange, opt => opt.MapFrom(o => o.Start))
                .ForMember(m => m.TimeRange, opt => opt.MapFrom(o => o.End));

            CreateMap<CommentModel, CommentForAdminOutputModel>();
            CreateMap<CommentModel, ContactOutputModel>();
            CreateMap<CommentInsertInputModel, CommentModel>();

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