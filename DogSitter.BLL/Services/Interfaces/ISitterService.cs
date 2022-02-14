using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface ISitterService
    {
        void Add(SitterModel sitterModel);
        void BlockProfileSitterById(int id);
        void ConfirmProfileSitterById(int id);
        void DeleteById(int id);
        List<SitterModel> GetAll();
        SitterModel GetById(int id);
        void Restore(int id);
        void Update(SitterModel sitterModel);
    }
}