using AutoMapper;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;

namespace DogSitter.API.Configs
{
    public class CustomMapperAPI : Profile
    {

        public CustomMapperAPI()
        {
            CreateMap<AdminInsertInputModel, AdminModel>().ReverseMap();
            CreateMap<AdminUpdateInputModel, AdminModel>().ReverseMap();
            CreateMap<AdminOutputModel, AdminModel>().ReverseMap();

            CreateMap<ContactOutputModel, ContactModel>().ReverseMap();
            CreateMap<ContactInsertInputModel, ContactModel>().ReverseMap();

            CreateMap<ContactOutputModel, ContactModel>().ReverseMap()
            .ForMember(dest => dest.ContactType, act => act.MapFrom(src => src.ContactType));
            CreateMap<ContactInsertInputModel, ContactModel>().ReverseMap()
            .ForMember(dest => dest.ContactType, act => act.MapFrom(src => src.ContactType));

            CreateMap<PassportInsertInputModel, PassportModel>().ReverseMap();
            CreateMap<PassportUpdateInputModel, PassportModel>().ReverseMap();
            CreateMap<PassportOutputModel, PassportModel>().ReverseMap();

            CreateMap<AddressOutputModel, AddressModel>().ReverseMap();
            CreateMap<AddressInputModel, AddressModel>().ReverseMap();

            CreateMap<SubwayStationOutputModel, SubwayStationOutputModel>().ReverseMap();
            CreateMap<SubwayStationInputModel, SubwayStationModel>().ReverseMap();
        }
    }
}