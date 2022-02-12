﻿using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

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

        public Contact GetContactByValue(string value) =>
            _context.Contacts.Where(c => !c.IsDeleted).Include(c => c.Sitter).Include(c => c.Customer).Include(c => c.Admin).FirstOrDefault(c => c.Value == value);


    }
}
