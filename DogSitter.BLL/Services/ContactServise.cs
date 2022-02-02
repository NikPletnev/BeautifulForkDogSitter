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
        private ContactRepository _rep = new ContactRepository();
        private MMapper _map = new MMapper();

        public void UpdateContact(int id, ContactModel contactModel)
        {
            var contact = _rep.GetContactById(id);

            if (contact == null)
            {
                throw new Exception("Rонтакт не найден");

            }          
            _rep.UpdateContact(_map.MapContactModelToContact(contactModel));
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
            _rep.AddContact(_map.MapContactModelToContact(contact));
        }

        public ContactModel GetContactById(int id)
        {
            var contact = _rep.GetContactById(id);
            if (contact == null)
            {
                throw new Exception("Контакт не найден");

            }
            
            return _map.MapContactToContactModel(contact);
        }

        public List<ContactModel> GetAllContacts()
        {
            return _map.MapContactToContactModel(_rep.GetAllContacts());
        }
    }
}
