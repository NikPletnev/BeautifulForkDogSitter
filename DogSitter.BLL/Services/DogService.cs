using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class DogService : IDogService
    {
        private DogRepository _rep;
        private IMapper _mapper;

        public DogService(IMapper mapper)
        {
            _rep = new DogRepository();
            _mapper = mapper;
        }

        public void UpdateDog(int id, DogModel dogModel)
        {
            var entity = _mapper.Map<Dog>(dogModel);
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
            _rep.AddDog(_mapper.Map<Dog>(dogModel));
        }

        public DogModel GetDogById(int id)
        {
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new Exception("Собака не найдена");
            }

            return _mapper.Map<DogModel>(dog);
        }

        public List<DogModel> GetAllDogs()
        {
            return _mapper.Map<List<DogModel>>(_rep.GetAllDogs());
        }
    }
}
