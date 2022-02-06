using AutoMapper;

namespace DogSitter.BLL.Configs
{
    public interface ICustomMapper
    {
        Mapper GetInstance();
        void InitCustomMapper();
    }
}