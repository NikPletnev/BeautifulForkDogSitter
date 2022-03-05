using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        void DeleteCustomerById(int id);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void UpdateCustomer(Customer customer, Customer entity);
        void UpdateCustomer(int id, bool isDeleted);
    }
}