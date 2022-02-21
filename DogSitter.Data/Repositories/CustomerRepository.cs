using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private DogSitterContext _context;

        public CustomerRepository(DogSitterContext context)
        {
            _context = context;
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

        public void UpdateCustomer(Customer customer, Customer entity)
        {   
            entity.FirstName = customer.FirstName;
            entity.LastName = customer.LastName;
            entity.Contacts = customer.Contacts;
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
