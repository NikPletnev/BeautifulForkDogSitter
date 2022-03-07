using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IDogService
    {
        int AddDog(int userId, DogModel dogModel);
        void DeleteDog(int userId, int id);
        List<DogModel> GetAllDogs();
        void RestoreDog(int id);
        void UpdateDog(int userId, int id, DogModel dogModel);
        List<DogModel> GetDogsByCustomerId(int id);
        DogModel GetDogById(int id);
    }
}