using DogSitter.BLL.Configs;
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
        private DogRepository _rep;

        public DogService()
        {
            _rep = new DogRepository();
        }

        public void UpdateDog(int id, DogModel dogModel)
        {
            var entity = DogMapper.GetInstance().Map<Dog>(dogModel);
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new Exception("Собака не найдена");
            }

            _rep.UpdateDog(entity);
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
            _rep.AddDog(DogMapper.GetInstance().Map <Dog>(dogModel));
        }

        public DogModel GetDogById(int id)
        {
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new Exception("Собака не найдена");
            }

            return DogMapper.GetInstance().Map <DogModel>(dog);
        }

        public List<DogModel> GetAllDogs()
        {
            return DogMapper.GetInstance().Map<List<DogModel>>(_rep.GetAllDogs());    
        }
    }
}
