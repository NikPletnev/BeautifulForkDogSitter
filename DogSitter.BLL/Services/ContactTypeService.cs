﻿using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class ContactTypeService
    {
        private ContactTypeRepository _rep;
        private IMapper _mapper;

        public ContactTypeService(IMapper mapper)
        {
            _rep = new ContactTypeRepository();
            _mapper = mapper;
        }

        public void UpdateContactType(int id, ContactTypeModel contactTypeModel)
        {
            var entity = _mapper.Map<ContactType>(contactTypeModel);
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
            _rep.AddContactType(_mapper.Map<ContactType>(contactType));
        }

        public ContactTypeModel GetContactTypeById(int id)
        {
            var contactType = _rep.GetContactTypeById(id);
            if (contactType == null)
            {
                throw new Exception("Тип контакта не найден");

            }
            return _mapper.Map<ContactTypeModel>(contactType);
        }

        public List<ContactTypeModel> GetAllContactTypes()
        {
            return _mapper.Map<List<ContactTypeModel>>(_rep.GetAllContactTypes());
        }
    }
}
