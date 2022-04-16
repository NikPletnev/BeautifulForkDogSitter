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
            CreateMap<ServiceModel, ServiceShortOutputModel>();

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
                .ForMember(m => m.SitterWorkTime, opt => opt.MapFrom(o => new WorkTimeModel { Id = o.SitterWorkTimeId }));

            CreateMap<OrderInsertInputModel, OrderOutputModel>();
            CreateMap<OrderInsertInputModel, OrderModel>();

            CreateMap<WorkTimeModel, WorkTimeOutputModel>();
            CreateMap<WorkTimeModel, WorkTimeShortOutputModel>();
            CreateMap<WorkTimeInsertInputModel, WorkTimeModel>();
            CreateMap<WorkTimeUpdateInputModel, WorkTimeModel>();

            CreateMap<CommentModel, CommentForAdminOutputModel>();
            CreateMap<CommentModel, ContactOutputModel>();
            CreateMap<CommentInsertInputModel, CommentModel>();

            CreateMap<WorkTimeModel, WorkTimeOutputModel>();
            CreateMap<WorkTimeModel, WorkTimeShortOutputModel>();
            CreateMap<WorkTimeInsertInputModel, WorkTimeOutputModel>();
            CreateMap<WorkTimeInsertInputModel, WorkTimeModel>();

        }
    }
}