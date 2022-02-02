using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL;

namespace DogSitter.BLL.Services
{
    public class ContactTypeService
    {
        private ContactTypeRepository _rep = new ContactTypeRepository();
        private MMapper _mapper = new MMapper();

        public void UpdateContactType(int id, ContactTypeModel contactTypeModel)
        {
            var contactType = _rep.GetContactTypeById(id);
            
            if (contactType == null)
            {
                throw new Exception("Тип контакта не найден"); 
            }
            
            _rep.UpdateContactType(_mapper.MapContactTypeModelToContactType(contactTypeModel));
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
            _rep.AddContactType(_mapper.MapContactTypeModelToContactType(contactType));
        }
        
        public ContactTypeModel GetContactTypeById(int id)
        {
            var contactType = _rep.GetContactTypeById(id);
            if (contactType == null)
            {
                throw new Exception("Тип контакта не найден");

            }
            return _mapper.MapContactTypeToContactTypeModel(contactType);
        }

        public List<ContactTypeModel> GetAllContactTypes()
        {
            return _mapper.MapContactTypeToContactTypeModel(_rep.GetAllContactTypes());
        }
    }
}
