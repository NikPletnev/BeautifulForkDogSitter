using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IDogService
    {
        void AddDog(DogModel dogModel);
        void DeleteDog(int id);
        List<DogModel> GetAllDogs();
        DogModel GetDogById(int id);
        void RestoreDog(int id);
        void UpdateDog(int id, DogModel dogModel);
    }
}