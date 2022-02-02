using AutoMapper;
using DogSitter.API.Models;
using DogSitter.BLL.Models;

namespace DogSitter.API.Configs
{
    public class CustomMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitMapper();
            }
            return _instance;
        }

        public static void InitMapper()
        {
            _instance = new Mapper(new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<AdminUpdateOutputModel, AdminModel>().ReverseMap();
                conf.CreateMap<AdminInsertInputModel, AdminModel>().ReverseMap();
                conf.CreateMap<ContactUpdateOutputModel, ContactModel>().ReverseMap();
                conf.CreateMap<ContactTypeInsertInputModel, ContactTypeModel>().ReverseMap();
                conf.CreateMap<ContactTypeUpdateOutputModel, ContactTypeModel>().ReverseMap();
                conf.CreateMap<AdminOutputModel, AdminModel>().ReverseMap();
                conf.CreateMap<DogUpdateOutputModel, DogModel>().ReverseMap();
                conf.CreateMap<DogInsertInputModel, DogModel>().ReverseMap();
                conf.CreateMap<PassportInsertInputModel, PassportModel>().ReverseMap();
                conf.CreateMap<PassportUpdateOutputModel, PassportModel>().ReverseMap();
            }));
        }
    }
}
