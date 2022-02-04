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
                conf.CreateMap<AddressOutputModel, AddressModel>().ReverseMap();
                conf.CreateMap<AddressInputModel, AddressInputModel>().ReverseMap();
                conf.CreateMap<SubwayStationOutputModel, SubwayStationOutputModel>().ReverseMap();
                conf.CreateMap<SubwayStationInputModel, SubwayStationModel>().ReverseMap();

            }));
        }
    }
}