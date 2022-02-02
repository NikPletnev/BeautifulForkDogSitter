using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Repositories
{
    public class CustomerRepository
    {
        private DogSitterContext _context;

        public CustomerRepository()
        {
            _context = DogSitterContext.GetInstance();
            _context = new DogSitterContext();
        }

        public Customer GetCustomerById(int id) =>
             _context.Customers.FirstOrDefault(x => x.Id == id);

        public List<Customer> GetAllCustomers() => 
            _context.Customers.Where(d => !d.IsDeleted).ToList();

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
            
            
        public void UpdateCustomer(Customer customer)
        {
            var entity = GetCustomerById(customer.Id);
            entity.FirstName = customer.FirstName;
            entity.LastName = customer.LastName;
            entity.Password = customer.Password;
            entity.Contacts = customer.Contacts;
            entity.IsDeleted = customer.IsDeleted;
            entity.Dogs = customer.Dogs;
            entity.Sitter = customer.Sitter;
            entity.Address = customer.Address;
            entity.Orders = customer.Orders;
            _context.SaveChanges();
        }

        public void DeleteCustomerById(int id)
        {
            if (_context.Customers.Any(x => x.Id == id))
            {
                var customer = GetCustomerById(id);
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public void UpdateCustomer(int id, bool IsDeleted)
        {
            Customer customer = GetCustomerById(id);
            customer.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }

    }
}
