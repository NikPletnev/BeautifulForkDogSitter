using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IDogRepository
    {
        void AddDog(Dog dog);
        List<Dog> GetAllDogs();
        Dog GetDogById(int id);
        void UpdateDog(Dog dog);
        void UpdateDog(int id, bool isDeleted);
    }
}