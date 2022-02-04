using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;

namespace DogSitter.BLL.Configs
{
    public class AdminMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitAdminMapper();
            }
            return _instance;
        }

        public static void InitAdminMapper()
        {
            _instance = new Mapper(new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<Admin, AdminModel>().ReverseMap();
                conf.CreateMap<Contact, ContactModel>()
                .ForMember(dest => dest.Value, act => act.MapFrom(src => src.Value)).ReverseMap();
                conf.CreateMap<ContactType, ContactTypeModel>().ReverseMap();
            }));
        }
    }
}
