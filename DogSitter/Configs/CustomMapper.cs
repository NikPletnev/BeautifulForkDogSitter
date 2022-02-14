using AutoMapper;
using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;

namespace DogSitter.API.Configs
{
    public class CustomMapper : Profile
    {
        private Mapper _instance;

        public CustomMapper()
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

            CreateMap<SitterInputModel, SitterModel>().ReverseMap();
            CreateMap<SitterOutputModel, SitterModel>().ReverseMap();

            CreateMap<SubwayStationOutputModel, SubwayStationOutputModel>().ReverseMap();
            CreateMap<SubwayStationInputModel, SubwayStationModel>().ReverseMap();
        }
    }
}