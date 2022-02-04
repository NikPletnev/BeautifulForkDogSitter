using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;

namespace DogSitter.BLL.Configs
{
    public class DogMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitDogMapper();
            }
            return _instance;
        }


        public static void InitDogMapper()
        {
            _instance = new Mapper(new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<Dog, DogModel>();
                conf.CreateMap<Customer, CustomerModel>().ReverseMap();
            }));
        }
    }
}
