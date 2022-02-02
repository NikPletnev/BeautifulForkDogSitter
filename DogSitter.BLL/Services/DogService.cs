using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Services
{
    public class DogService
    {
        private DogRepository _rep = new DogRepository();
        private MMapper _map = new MMapper();

        public void UpdateDog(int id, DogModel dogModel)
        {
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new Exception("Собака не найдена");
            }

            _rep.UpdateDog(_map.MapDogModelToDog(dogModel));
        }

        public void DeleteDog(int id)
        {
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new Exception("Собака не найдена");
            }

            _rep.UpdateDog(id, true);
        }

        public void RestoreDog(int id)
        {
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new Exception("Собака не найдена");
            }

            _rep.UpdateDog(id, false);
        }

        public void AddDog (DogModel dogModel)
        {
            _rep.AddDog(_map.MapDogModelToDog(dogModel));
        }

        public DogModel GetDogById(int id)
        {
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new Exception("Собака не найдена");
            }

            return _map.MapDogToDogModel(dog);
        }

        public List<DogModel> GetAllDogs()
        {
            return _map.MapDogToDogModel(_rep.GetAllDogs());    
        }
    }
}
