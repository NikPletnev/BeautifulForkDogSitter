using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;

namespace DogSitter.BLL.Configs
{
    public class MapperConfigs
    {
        public MapperConfiguration ConfContactType { get; set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<ContactType, ContactTypeModel>();
            });

        public MapperConfiguration ConfContact { get; set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<Contact, ContactModel>();
                conf.CreateMap<ContactType, ContactTypeModel>();
            });

        public MapperConfiguration ConfPassport { get; set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<Passport, PassportModel>();
                conf.CreateMap<Sitter, SitterModel>();
            });

        public MapperConfiguration ConfAdmin { get; set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<Admin, AdminModel>();
                conf.CreateMap<Contact, ContactModel>()
                .ForMember(dest => dest.Value, act => act.MapFrom(src => src.Value));
                conf.CreateMap<ContactType, ContactTypeModel>();
            });

        public MapperConfiguration ConfDog { get; set; } = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<Dog, DogModel>();
                conf.CreateMap<Customer, CustomerModel>();
            });
  
    }
}
