using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface ISitterService
    {
        void AddSitter(SitterModel sitterModel);
        void DeleteSitterById(int id);
        List<SitterModel> GetAllSitters();
        SitterModel GetSitterById(int id);
        void RestoreSitter(int id);
        void UpdateSitter(SitterModel sitterModel);
    }
}