﻿using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface ICustomerService
    {
        void AddCustomer(CustomerModel customer);
        void DeleteCustomerById(int id);
        List<CustomerModel> GetAllCustomers();
        CustomerModel GetCustomerById(int id);
        void RestoreCustomer(int id);
        void UpdateCustomer(CustomerModel customer);
    }
}