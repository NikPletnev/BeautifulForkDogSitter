using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;


namespace DogSitter.BLL.Config
{
    public static class CustomMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitCustomMapper();
            }
            return _instance;
        }
        public static void InitCustomMapper()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerModel>().ReverseMap();
                cfg.CreateMap<Sitter, SitterModel>().ReverseMap();
                cfg.CreateMap<Serviсe, ServiceModel>().ReverseMap();
                cfg.CreateMap<WorkTime, WorkTimeModel>().ReverseMap();
            }));

        }
    }
}