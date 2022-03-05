using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface ICustomerService
    {
        int AddCustomer(CustomerModel customer);
        void DeleteCustomerById(int userId, int id);
        List<CustomerModel> GetAllCustomers();
        CustomerModel GetCustomerById(int id);
        void RestoreCustomer(int id);
        void UpdateCustomer(int id, CustomerModel customer);
    }
}