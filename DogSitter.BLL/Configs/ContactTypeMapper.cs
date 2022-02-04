using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;

namespace DogSitter.BLL.Configs
{
    public class ContactTypeMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitContactTypeMapper();
            }
            return _instance;
        }


        public static void InitContactTypeMapper()
        {
            _instance = new Mapper(new MapperConfiguration(
                conf =>
                {
                    conf.CreateMap<ContactType, ContactTypeModel>().ReverseMap();
                }));

        }
    }
}
