using AutoMapper;
using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repository;
        private IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CustomerModel GetCustomerById(int id)
        {
            var customer = _repository.GetCustomerById(id);
            if (customer == null)
            {
                throw new Exception("Клиент не найден");

            }
            return _mapper.Map<CustomerModel>(customer);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            var customers = _repository.GetAllCustomers();
            return _mapper.Map<List<CustomerModel>>(customers);
        }

        public void AddCustomer(CustomerModel customerModel)
        {
            var customer = _mapper.Map<Customer>(customerModel);
            customer.Password = PasswordHash.HashPassword(customer.Password);
            _repository.AddCustomer(customer);
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            var customerModel = _mapper.Map<Customer>(customer);
            var entity = _repository.GetCustomerById(customer.Id);
            if (entity == null)
            {
                throw new Exception("Клиент не найден");

            }
            _repository.UpdateCustomer(customerModel);
        }

        public void DeleteCustomerById(int id)
        {
            var entity = _repository.GetCustomerById(id);
            if (entity == null)
            {
                throw new Exception("Клиент не найден");

            }
            bool Delete = true;
            _repository.UpdateCustomer(id, Delete);
        }

        public void RestoreCustomer(int id)
        {
            var entity = _repository.GetCustomerById(id);
            if (entity == null)
            {
                throw new Exception("Клиент не найден");

            }
            bool Delete = false;
            _repository.UpdateCustomer(id, Delete);
        }

    }
}
