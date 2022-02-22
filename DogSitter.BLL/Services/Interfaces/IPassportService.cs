using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IPassportService
    {
        void UpdatePassport(int id, PassportModel passportModel);
    }
}