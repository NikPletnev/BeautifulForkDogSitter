using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IDogRepository
    {
        int AddDog(Dog dog);
        List<Dog> GetAllDogs();
        List<Dog> GetAllDogsByCustomerId(int id);
        Dog GetDogById(int id);
        void UpdateDog(Dog dog);
        void UpdateDog(int id, bool isDeleted);
    }
}