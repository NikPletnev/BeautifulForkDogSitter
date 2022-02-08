using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private CustomerRepository _repository;

        public CustomerService()
        {
            _repository = new CustomerRepository();
        }

        public CustomerModel GetCustomerById(int id)
        {
            var customer = _repository.GetCustomerById(id);
            if (customer == null)
            {
                throw new Exception("Клиент не найден");

            }
            return CustomMapper.GetInstance().Map<CustomerModel>(customer);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            var customers = _repository.GetAllCustomers();
            return CustomMapper.GetInstance().Map<List<CustomerModel>>(customers);
        }

        public void AddCustomer(CustomerModel customer)
        {
            var customerModel = CustomMapper.GetInstance().Map<Customer>(customer);
            _repository.AddCustomer(customerModel);
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            var customerModel = CustomMapper.GetInstance().Map<Customer>(customer);
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
