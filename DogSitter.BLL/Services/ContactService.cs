
using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _rep;
        private readonly CustomMapper _map;

        public ContactService(IContactRepository contactRepository)
        {
            _rep = contactRepository;
        }

        public void UpdateContact(int id, ContactModel contactModel)
        {
            var entity = _map.GetInstance().Map<Contact>(contactModel);
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

        public void AddContact(ContactModel contact)
        {
            _rep.AddContact(_map.GetInstance().Map<Contact>(contact));
        }

        public ContactModel GetContactById(int id)
        {
            var contact = _rep.GetContactById(id);
            if (contact == null)
            {
                throw new Exception("Контакт не найден");

            }

            return _map.GetInstance().Map<ContactModel>(contact);
        }

        public List<ContactModel> GetAllContacts()
        {
            return _map.GetInstance().Map<List<ContactModel>>(_rep.GetAllContacts());
        }
    }
}
