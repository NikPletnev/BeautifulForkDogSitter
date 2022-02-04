using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL;
using DogSitter.BLL.Configs;

namespace DogSitter.BLL.Services
{
    public class ContactTypeService
    {
        private ContactTypeRepository _rep;

        public ContactTypeService()
        {
            _rep = new ContactTypeRepository();
        }

        public void UpdateContactType(int id, ContactTypeModel contactTypeModel)
        {
            var entity = CustomMapper.GetInstance().Map<ContactType>(contactTypeModel);
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
            _rep.AddContactType(CustomMapper.GetInstance().Map<ContactType>(contactType));
        }
        
        public ContactTypeModel GetContactTypeById(int id)
        {
            var contactType = _rep.GetContactTypeById(id);
            if (contactType == null)
            {
                throw new Exception("Тип контакта не найден");

            }
            return CustomMapper.GetInstance().Map<ContactTypeModel>(contactType);
        }

        public List<ContactTypeModel> GetAllContactTypes()
        {
            return CustomMapper.GetInstance().Map<List<ContactTypeModel>>(_rep.GetAllContactTypes());
        }
    }
}
