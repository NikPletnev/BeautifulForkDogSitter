using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Services
{
    public class ContactServise
    {
        private ContactRepository _rep;

        public ContactServise()
        {
            _rep = new ContactRepository();
        }

        public void UpdateContact(int id, ContactModel contactModel)
        {
            var entity = ContactMapper.GetInstance().Map<Contact>(contactModel);
            var contact = _rep.GetContactById(id);

            if (contact == null)
            {
                throw new Exception("Контакт не найден");

            }          
            _rep.UpdateContact(entity);
        }

        public void DeleteContact(int id)
        {
            var contact = _rep.GetContactById(id);

            if (contact == null)
            {
                throw new Exception("Контакт не найден");
            }

            _rep.UpdateContact(id, true);
        }

        public void RestoreContact(int id)
        {
            var contact = _rep.GetContactById(id);

            if (contact == null)
            {
                throw new Exception("Контакт не найден");
            }

            _rep.UpdateContact(id, false);
        }

        public void AddContactType(ContactModel contact)
        {
            _rep.AddContact(ContactMapper.GetInstance().Map<Contact>(contact));
        }

        public ContactModel GetContactById(int id)
        {
            var contact = _rep.GetContactById(id);
            if (contact == null)
            {
                throw new Exception("Контакт не найден");

            }
            
            return ContactMapper.GetInstance().Map<ContactModel>(contact);
        }

        public List<ContactModel> GetAllContacts()
        {
            return ContactMapper.GetInstance().Map<List<ContactModel>>(_rep.GetAllContacts());
        }
    }
}
