using AutoMapper;
using DogSitter.API.Models;
using DogSitter.BLL.Models;

namespace DogSitter.API.Configs
{
    public class CustomMapper
    {
        private Mapper _instance;

        public Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitMapper();
            }
            return _instance;
        }

        public void InitMapper()
        {
            _instance = new Mapper(new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<AdminInsertInputModel, AdminModel>().ReverseMap();
                conf.CreateMap<AdminUpdateInputModel, AdminModel>().ReverseMap();
                conf.CreateMap<AdminOutputModel, AdminModel>().ReverseMap();

                conf.CreateMap<ContactOutputModel, ContactModel>().ReverseMap()
                .ForMember(dest => dest.ContactType, act => act.MapFrom(src => src.ContactType));
                conf.CreateMap<ContactInsertInputModel, ContactModel>().ReverseMap()
                .ForMember(dest => dest.ContactType, act => act.MapFrom(src => src.ContactType));


                conf.CreateMap<DogUpdateInputModel, DogModel>().ReverseMap();
                conf.CreateMap<DogInsertInputModel, DogModel>().ReverseMap();
                conf.CreateMap<DogOutputModel, DogModel>().ReverseMap();

                conf.CreateMap<PassportInsertInputModel, PassportModel>().ReverseMap();
                conf.CreateMap<PassportUpdateInputModel, PassportModel>().ReverseMap();
                conf.CreateMap<PassportOutputModel, PassportModel>().ReverseMap();

            }));
        }
    }
}
