using AutoMapper;

namespace DogSitter.API.Configs
{
    public interface ICustomMapper
    {
        Mapper GetInstance();
        void InitMapper();
    }
}