using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class DogService : IDogService
    {
        private IDogRepository _rep;
        private ICustomerRepository _customerRepository;
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public DogService(IMapper mapper, IDogRepository dogRepository, ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _rep = dogRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void UpdateDog(int userId, int id, DogModel dogModel)
        {
            if (dogModel.Name == String.Empty ||
                dogModel.Age <= 0 ||
                dogModel.Weight <= 0 ||
                dogModel.Breed == String.Empty)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to update dog");
            }

            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new EntityNotFoundException($"Dog {id} was not found");
            }

            if (dog.Customer.Id != userId)
            {
                throw new AccessException("Not enough rights");
            }

            var entity = _mapper.Map<Dog>(dogModel);
            _rep.UpdateDog(entity);
        }

        public void DeleteDog(int userId, int id)
        {
            var dog = _rep.GetDogById(id);
            if (dog == null)
            {
                throw new EntityNotFoundException($"Dog {id} was not found");
            }

            if (_userRepository.GetUserById(userId).Role != Role.Admin)
            {
                if (dog.Customer.Id != userId)
                {
                    throw new AccessException("Not enough rights");
                }
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

        public void AddDog(int userId, DogModel dogModel)
        {
            if (dogModel.Name == String.Empty ||
                dogModel.Age <= 0 ||
                dogModel.Weight <= 0 ||
                dogModel.Breed == String.Empty)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to create new dog");
            }
            dogModel.Customer = _mapper.Map<CustomerModel>(_userRepository.GetUserById(userId));
            _rep.AddDog(_mapper.Map<Dog>(dogModel));
        }

        public List<DogModel> GetAllDogs()
        {
            return _mapper.Map<List<DogModel>>(_rep.GetAllDogs());
        }

        public DogModel GetDogById(int id)
        {
            return _mapper.Map<DogModel>(_rep.GetDogById(id));
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
