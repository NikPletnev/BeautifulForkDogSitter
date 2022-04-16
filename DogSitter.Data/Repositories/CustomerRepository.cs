using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DogSitterContext _context;

        public CustomerRepository(DogSitterContext context)
        {
            _context = context;
        }

        public Customer GetCustomerById(int id) =>
             _context.Customers.Where(x => x.Id == id)
            .Include(w => w.Orders)
            .Include(w => w.Dogs)
            .Include(w => w.Sitter)
            .Include(w => w.Contacts)
            .Include(w => w.Comments)

            .FirstOrDefault();

        public List<Customer> GetAllCustomers() =>
            _context.Customers.Where(d => !d.IsDeleted).Include(w => w.Orders).ToList();

        public int AddCustomer(Customer customer)
        {
            var entity = _context.Customers.Add(customer);
            _context.SaveChanges();
            return entity.Entity.Id;
        }

        public void UpdateCustomer(Customer customer, Customer entity)
        {
            entity.FirstName = customer.FirstName;
            entity.LastName = customer.LastName;
            entity.Dogs = customer.Dogs;
            entity.Sitter = customer.Sitter;
            entity.Address = customer.Address;
            _context.SaveChanges();
        }

        public void DeleteCustomerById(int id)
        {
            var customer = GetCustomerById(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(int id, bool isDeleted)
        {
            Customer customer = GetCustomerById(id);
            customer.IsDeleted = isDeleted;
            _context.SaveChanges();
        }

        public void ChangeCustomerAddress(Customer customer, Address address)
        {
            customer.Address = address;
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }
    }
}
