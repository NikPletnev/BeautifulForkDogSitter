using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class ContactTypeService : IContactTypeService
    {
        private readonly IContactTypeRepository _rep;
        private readonly CustomMapper _map;

        public ContactTypeService(IContactTypeRepository contactTypeRepository)
        {
            _rep = contactTypeRepository;
            _map = new CustomMapper();
        }

        public void UpdateContactType(int id, ContactTypeModel contactTypeModel)
        {
            var entity = _map.GetInstance().Map<ContactType>(contactTypeModel);
            var contactType = _rep.GetContactTypeById(id);

            if (contactType == null)
            {
                throw new Exception("Тип контакта не найден");
            }

            _rep.UpdateContactType(entity);
        }

        public void DeleteContactType(int id)
        {
            var contactType = _rep.GetContactTypeById(id);

            if (contactType == null)
            {
                throw new Exception("Такой тип контакта не найден");
            }

            _rep.UpdateContactType(id, true);
        }

        public void RestoreContactType(int id)
        {
            var contactType = _rep.GetContactTypeById(id);

            if (contactType == null)
            {
                throw new Exception("Такой тип контакта не найден");
            }

            _rep.UpdateContactType(id, false);
        }

        public void AddContactType(ContactTypeModel contactType)
        {
            _rep.AddContactType(_map.GetInstance().Map<ContactType>(contactType));
        }

        public ContactTypeModel GetContactTypeById(int id)
        {
            var contactType = _rep.GetContactTypeById(id);
            if (contactType == null)
            {
                throw new Exception("Тип контакта не найден");

            }
            return _map.GetInstance().Map<ContactTypeModel>(contactType);
        }

        public List<ContactTypeModel> GetAllContactTypes()
        {
            return _map.GetInstance().Map<List<ContactTypeModel>>(_rep.GetAllContactTypes());
        }
    }
}
