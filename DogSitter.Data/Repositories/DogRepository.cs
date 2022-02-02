using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Repositories
{
    public class DogRepository
    {
        private DogSitterContext _context;

        public DogRepository()
        {
            _context = new DogSitterContext();
        }

        public List<Dog> GetAllDogs() =>  
                    _context.Dogs.Where(d => !d.IsDeleted).ToList();

        public Dog GetDogById(int id) =>
                     _context.Dogs.FirstOrDefault(x => x.Id == id);

        public void AddDog(Dog dog)
        {
            _context.Dogs.Add(dog);
            _context.SaveChanges();
        }

        public void DeleteDog(int id)
        {
            Dog dog = GetDogById(id);
            _context.Dogs.Remove(dog);
            _context.SaveChanges();
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

        public void UpdateDog(int id, bool IsDeleted)
        {
            var entity = GetDogById(id);
            entity.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }


    }
}
