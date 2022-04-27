using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DogSitterContext _context;

        public ContactRepository(DogSitterContext context)
        {
            _context = context;
        }

        public List<Contact> GetAllContacts() =>
                     _context.Contacts.Where(c => !c.IsDeleted).ToList();

        public Contact GetContactByValue(string value) =>
            _context.Contacts.Where(c => !c.IsDeleted).Include(c => c.User).FirstOrDefault(c => c.Value == value);

        public List<Contact> GetAllContactsBySitterId(int id)
           => _context.Sitters.FirstOrDefault(x => x.Id == id).Contacts.Where(c => !c.IsDeleted).ToList();

        public List<Contact> GetAllContactsByCustomerId(int id)
           => _context.Customers.FirstOrDefault(x => x.Id == id).Contacts.Where(c => !c.IsDeleted).ToList();

        public void UpdateContact(Contact contact, string value)
        {
            contact.Value = value;
            contact.User.ResetToken = null;
            contact.User.ResetTokenExpires = null;
            _context.SaveChanges();
        }

    }
}
