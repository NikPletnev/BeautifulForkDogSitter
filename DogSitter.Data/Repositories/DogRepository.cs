using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly DogSitterContext _context;

        public DogRepository(DogSitterContext context)
        {
            _context = context;
        }

        public List<Dog> GetAllDogs() =>
                    _context.Dogs.Where(d => !d.IsDeleted).ToList();

        public Dog GetDogById(int id) =>
                     _context.Dogs.Where(x => x.Id == id)
                     .Include(w => w.Customer)
                     .FirstOrDefault();

        public int AddDog(Dog dog)
        {
            _context.Dogs.Add(dog);
            _context.SaveChanges();
            return dog.Id;
        }

        public void UpdateDog(Dog dog)
        {
            var entity = GetDogById(dog.Id);
            entity.Name = dog.Name;
            entity.Description = dog.Description;
            entity.Breed = dog.Breed;
            entity.Age = dog.Age;
            entity.Weight = dog.Weight;
            _context.SaveChanges();
        }

        public void UpdateDog(int id, bool isDeleted)
        {
            var entity = GetDogById(id);
            entity.IsDeleted = isDeleted;
            _context.SaveChanges();
        }

        public List<Dog> GetAllDogsByCustomerId(int id) =>
            _context.Dogs.Where(x => x.Customer.Id == id).Where(x => !x.IsDeleted).ToList();

    }
}
