
using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class ContactService : IContactService
    {
        private ContactRepository _rep;
        private IMapper _mapper;

        public ContactService(IMapper mapper)
        {
            _rep = new ContactRepository();
            _mapper = mapper;
        }

        public void UpdateContact(int id, ContactModel contactModel)
        {
            var entity = _mapper.Map<Contact>(contactModel);
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
            _rep.AddContact(_mapper.Map<Contact>(contact));
        }

        public ContactModel GetContactById(int id)
        {
            var contact = _rep.GetContactById(id);
            if (contact == null)
            {
                throw new Exception("Контакт не найден");

            }

            return _mapper.Map<ContactModel>(contact);
        }

        public List<ContactModel> GetAllContacts()
        {
            return _mapper.Map<List<ContactModel>>(_rep.GetAllContacts());
        }
    }
}
