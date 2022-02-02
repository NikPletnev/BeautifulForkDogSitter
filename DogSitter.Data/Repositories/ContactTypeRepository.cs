using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Repositories
{
    public class ContactTypeRepository
    {
        private DogSitterContext _context;

        public ContactTypeRepository()
        {
            _context = new DogSitterContext();
        }
        
        public List<ContactType> GetAllContactTypes() =>
                _context.ContactTypes.Where(c => !c.IsDeleted).ToList();        
        
        public ContactType GetContactTypeById(int id) =>
                _context.ContactTypes.FirstOrDefault(c => c.Id == id);      
        
        public void AddContactType(ContactType contactType)
        {
            _context.ContactTypes.Add(contactType);
            _context.SaveChanges();
        }
        
        public void UpdateContactType(int id, bool IsDeleted)
        {
            var entity = GetContactTypeById(id);
            entity.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
        
        public void UpdateContactType(ContactType contactType)
        {
            var entity = GetContactTypeById(contactType.Id);
            entity.Name = contactType.Name;
            _context.SaveChanges();
        }   
    }
}
