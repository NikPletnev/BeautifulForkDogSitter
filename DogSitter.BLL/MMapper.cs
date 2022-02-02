using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL
{
    public class MMapper
    {
        private MapperConfigs _conf = new MapperConfigs();
        public List<ContactTypeModel> MapContactTypeToContactTypeModel(List<ContactType> contactTypes)
        {
            return new Mapper(_conf.ConfContactType).Map<List<ContactType>, List<ContactTypeModel>>(contactTypes);
        }

        public ContactType MapContactTypeModelToContactType(ContactTypeModel contactType)
        {
            return new Mapper(_conf.ConfContactType).Map<ContactTypeModel, ContactType>(contactType);
        }

        public ContactTypeModel MapContactTypeToContactTypeModel(ContactType contactType)
        {
            return new Mapper(_conf.ConfContactType).Map<ContactType, ContactTypeModel>(contactType);
        }

        public List<ContactModel> MapContactToContactModel(List<Contact> contacts)
        {
            return new Mapper(_conf.ConfContact).Map<List<Contact>, List<ContactModel>>(contacts);
        }

        public ContactModel MapContactToContactModel(Contact contact)
        {
            return new Mapper(_conf.ConfContact).Map<Contact, ContactModel>(contact);
        }

        public Contact MapContactModelToContact(ContactModel contactModel)
        {
            return new Mapper(_conf.ConfContact).Map<ContactModel, Contact>(contactModel); 
        }

        public Passport MapPassportModelToPassport(PassportModel passportModel)
        {
            return new Mapper(_conf.ConfPassport).Map<PassportModel,Passport>(passportModel);
        }

        public PassportModel MapPassportToPassportModel(Passport passport)
        {
            return new Mapper(_conf.ConfPassport).Map<Passport, PassportModel>(passport);
        }

        public List<AdminModel> MapAdminToAdminModel(List<Admin> admins)
        {
            return new Mapper(_conf.ConfAdmin).Map<List<Admin>, List<AdminModel>>(admins);
        }

        public AdminModel MapAdminToAdminModel(Admin admin)
        {
            return new Mapper(_conf.ConfAdmin).Map<Admin, AdminModel>(admin);
        }

        public Admin MapAdminModelToAdmin(AdminModel admin)
        {
            return new Mapper(_conf.ConfAdmin).Map<AdminModel, Admin>(admin);
        }

        public Dog MapDogModelToDog(DogModel dogModel)
        {
            return new Mapper(_conf.ConfDog).Map<DogModel, Dog>(dogModel);
        }

        public List<DogModel> MapDogToDogModel(List<Dog> dogs)
        {
            return new Mapper(_conf.ConfDog).Map<List<Dog>, List<DogModel>>(dogs);
        }

        public DogModel MapDogToDogModel(Dog dog)
        {
            return new Mapper(_conf.ConfDog).Map<Dog, DogModel>(dog);
        }

    }
}
