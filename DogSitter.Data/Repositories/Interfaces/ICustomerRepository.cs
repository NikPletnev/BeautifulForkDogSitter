using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        void DeleteCustomerById(int id);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
        void UpdateCustomer(int id, bool isDeleted);
    }
}