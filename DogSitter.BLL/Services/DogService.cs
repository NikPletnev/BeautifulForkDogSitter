using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class DogService
    {
        private DogRepository _rep;
        private readonly CustomMapper _map;

        public DogService()
        {
            _rep = new DogRepository();
            _map = new CustomMapper();
        }

        public void UpdateDog(int id, DogModel dogModel)
        {
            var entity = _map.GetInstance().Map<Dog>(dogModel);
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

        public void AddDog(DogModel dogModel)
        {
            _rep.AddDog(_map.GetInstance().Map<Dog>(dogModel));
        }

        public DogModel GetDogById(int id)
        {
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new Exception("Собака не найдена");
            }

            return _map.GetInstance().Map<DogModel>(dog);
        }

        public List<DogModel> GetAllDogs()
        {
            return _map.GetInstance().Map<List<DogModel>>(_rep.GetAllDogs());
        }
    }
}
