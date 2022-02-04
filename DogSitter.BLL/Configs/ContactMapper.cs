using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;

namespace DogSitter.BLL.Configs
{
    public class ContactMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitContactMapper();
            }
            return _instance;
        }

        public static void InitContactMapper()
        {
            _instance = new Mapper(new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<Contact, ContactModel>().ReverseMap();
                conf.CreateMap<ContactType, ContactTypeModel>().ReverseMap();
            }));
        }
    }
}
