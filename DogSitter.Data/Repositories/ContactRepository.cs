using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private DogSitterContext _context;

        public ContactRepository(DogSitterContext context)
        {
            _context = context;
        }

        public List<Contact> GetAllContacts() =>
                     _context.Contacts.Where(c => !c.IsDeleted).ToList();

        public Contact GetContactById(int id) =>
             _context.Contacts.FirstOrDefault(c => c.Id == id);

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void UpdateContact(Contact entity, Contact contact)
        {
            entity.Value = contact.Value;
            entity.ContactType = contact.ContactType;
            entity.Sitter = contact.Sitter;
            entity.Admin = contact.Admin;
            entity.Customer = contact.Customer;
            _context.SaveChanges();
        }

        public void UpdateContact(Contact contact, bool isDeleted)
        {
            contact.IsDeleted = isDeleted;
            _context.SaveChanges();
        }

        public List<Contact> GetAllContactsByAdminId(int id)       
           => _context.Admins.FirstOrDefault(x => x.Id == id).Contacts.Where(c => !c.IsDeleted).ToList();

        public List<Contact> GetAllContactsBySitterId(int id)
           => _context.Sitters.FirstOrDefault(x => x.Id == id).Contacts.Where(c => !c.IsDeleted).ToList();

        public List<Contact> GetAllContactsByCustomerId(int id)
           => _context.Customers.FirstOrDefault(x => x.Id == id).Contacts.Where(c => !c.IsDeleted).ToList();

    }
}
