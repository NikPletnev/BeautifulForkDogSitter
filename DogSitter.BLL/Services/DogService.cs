using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class DogService : IDogService
    {
        private IDogRepository _rep;
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public DogService(IMapper mapper, IDogRepository dogRepository, ICustomerRepository customerRepository)
        {
            _rep = dogRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public void UpdateDog(int id, DogModel dogModel)
        {
            if (dogModel.Name == String.Empty ||
                dogModel.Age <= 0 ||
                dogModel.Weight <= 0 ||
                dogModel.Breed == String.Empty)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to update dog");
            }
            var entity = _mapper.Map<Dog>(dogModel);
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new EntityNotFoundException($"Dog {id} was not found");
            }

            _rep.UpdateDog(entity);
        }

        public void DeleteDog(int id)
        {
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new EntityNotFoundException($"Dog {id} was not found");
            }

            _rep.UpdateDog(id, true);
        }

        public void RestoreDog(int id)
        {
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new EntityNotFoundException($"Dog {id} was not found");
            }

            _rep.UpdateDog(id, false);
        }

        public void AddDog(DogModel dogModel)
        {
            if (dogModel.Name == String.Empty ||
                dogModel.Age <= 0 ||
                dogModel.Weight <= 0 ||
                dogModel.Breed == String.Empty)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to create new dog");
            }
            _rep.AddDog(_mapper.Map<Dog>(dogModel));
        }

        public DogModel GetDogById(int id)
        {
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new Exception($"Dog {id} was not found");
            }

            return _mapper.Map<DogModel>(dog);
        }

        public List<DogModel> GetAllDogs()
        {
            return _mapper.Map<List<DogModel>>(_rep.GetAllDogs());
        }

        public List<DogModel> GetDogsByCustomerId(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                throw new EntityNotFoundException($"Customer {id} was not found");
            }

            return _mapper.Map<List<DogModel>>(_rep.GetAllDogsByCustomerId(id));
        }
    }
}
