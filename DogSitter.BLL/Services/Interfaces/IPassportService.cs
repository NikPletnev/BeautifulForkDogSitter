using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IPassportService
    {
        void AddPassport(PassportModel passportModel);
        PassportModel GetPassportById(int id);
        void UpdatePassport(int id, PassportModel passportModel);
    }
}