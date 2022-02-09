using AutoMapper;
using DogSitter.API.Models;
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

            CreateMap<ContactUpdateInputModel, ContactModel>().ReverseMap();
            CreateMap<ContactOutputModel, ContactModel>().ReverseMap();
            CreateMap<ContactInsertInputModel, ContactModel>().ReverseMap();

            CreateMap<ContactTypeInputModel, ContactTypeModel>().ReverseMap();
            CreateMap<ContactOutputModel, ContactModel>().ReverseMap();

            CreateMap<DogUpdateInputModel, DogModel>().ReverseMap();
            CreateMap<DogInsertInputModel, DogModel>().ReverseMap();
            CreateMap<DogOutputModel, DogModel>().ReverseMap();

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