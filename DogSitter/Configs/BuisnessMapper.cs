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

            CreateMap<AddressModel, AddressOutputModel>();
            CreateMap<AddressInputModel, AddressModel>();

            CreateMap<ServiceInsertInputModel, ServiceModel>();
            CreateMap<ServiceUpdateInputModel, ServiceModel>();
            CreateMap<ServiceModel, ServiceOutputModel>();

            CreateMap<SitterInsertInputModel, SitterModel>();
            CreateMap<SitterModel, SitterOutputModel>();

            CreateMap<CustomerModel, CustomerOutputModel>();
            CreateMap<CustomerInputModel, CustomerModel>();            

            CreateMap<SubwayStationModel, SubwayStationOutputModel>();
            CreateMap<SubwayStationInputModel, SubwayStationModel>();
            //CreateMap<SubwayStationOutputModel, SubwayStationModel>();


            CreateMap<DogModel, DogOutputModel>();
            CreateMap<DogUpdateInputModel, DogModel>();

            CreateMap<OrderModel, OrderOutputModel>();
            CreateMap<OrderUpdateCommentAndMarkModel, OrderModel>();


            CreateMap<ContactModel, CommentForAdminOutputModel>();
            CreateMap<ContactModel, ContactOutputModel>();
            CreateMap<CommentInsertInputModel, CommentModel>();


        }
    }
}