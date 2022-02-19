using AutoMapper;
using DogSitter.API.Models;
using DogSitter.BLL.Models;

namespace DogSitter.API.Configs
{
    public class CustomMapperAPI : Profile
    {

        public CustomMapperAPI()
        {
            CreateMap<AdminInsertInputModel, AdminModel>();
            CreateMap<AdminUpdateInputModel, AdminModel>();
            CreateMap<AdminModel, AdminOutputModel>();

            CreateMap<ContactModel, ContactOutputModel>();
            CreateMap<ContactInsertInputModel, ContactModel>();

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
        }
    }
}