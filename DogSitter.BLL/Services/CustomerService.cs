using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repository;
        private IMapper _mapper;
        private IUserRepository _userRepository;

        public CustomerService(ICustomerRepository repository, IMapper mapper, IUserRepository userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public CustomerModel GetCustomerById(int id)
        {
            var customer = _repository.GetCustomerById(id);
            if (customer == null)
            {
                throw new EntityNotFoundException("Customer was not found");

            }
            return _mapper.Map<CustomerModel>(customer);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            var customers = _repository.GetAllCustomers();
            return _mapper.Map<List<CustomerModel>>(customers);
        }

        public int AddCustomer(CustomerModel customerModel)
        {
            if(customerModel.Address.SubwayStations.Count != 0)
            {
                foreach (var item in customerModel.Address.SubwayStations)
                {
                    if(item.Id < 0 && item.Id >72)
                    {
                        throw new ServiceNotEnoughDataExeption($"Subway stantion {item.Id} has no exist");
                    }
                }
            }

            var customer = _mapper.Map<Customer>(customerModel);
            customer.Role = Role.Customer;
            customer.Password = PasswordHash.HashPassword(customer.Password);
            var id = _repository.AddCustomer(customer);
            return id;
        }

        public void UpdateCustomer(int id, CustomerModel customer)
        {
            if (customer.Address.SubwayStations.Count != 0)
            {
                foreach (var item in customer.Address.SubwayStations)
                {
                    if (item.Id < 0 && item.Id > 72)
                    {
                        throw new ServiceNotEnoughDataExeption($"Subway stantion {item.Id} has no exist");
                    }
                }
            }
            var customerModel = _mapper.Map<Customer>(customer);
            var entity = _repository.GetCustomerById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Customer was not found");

            }
            _repository.UpdateCustomer(customerModel, entity);
        }

        public void DeleteCustomerById(int userId, int id)
        {
            var entity = _repository.GetCustomerById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Customer was not found");

            }
            if (_userRepository.GetUserById(userId).Role != Role.Admin && userId != id)
            {
                throw new AccessException("Not enough rights");
            }

            bool Delete = true;
            _repository.UpdateCustomer(id, Delete);
        }

        public void RestoreCustomer(int id)
        {
            var entity = _repository.GetCustomerById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Customer was not found");

            }
            bool Delete = false;
            _repository.UpdateCustomer(id, Delete);
        }

    }
}
