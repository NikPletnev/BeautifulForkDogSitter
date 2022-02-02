using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Repositories
{
    public class ContactRepository
    {
        private DogSitterContext _context;

        public ContactRepository()
        {
            _context = DogSitterContext.GetInstance();
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
       
        public void UpdateContact(Contact contact)
        {
            var entity = GetContactById(contact.Id);
            entity.Value = contact.Value;
            entity.ContactType = contact.ContactType;
            entity.Sitter = contact.Sitter;
            entity.Admin = contact.Admin;
            entity.Customer = contact.Customer;
            _context.SaveChanges();
        }

        public void UpdateContact(int id, bool isDeleted)
        {
            var entity = GetContactById(id);
            entity.IsDeleted = isDeleted;
            _context.SaveChanges();
        }

    }
}
