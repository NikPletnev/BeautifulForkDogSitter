﻿using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;


namespace DogSitter.BLL.Configs
{
    public static class CustomMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitCustomMapper();
            }
            return _instance;
        }
        public static void InitCustomMapper()
        {
            _instance = new Mapper(new MapperConfiguration(conf =>
            {
                conf.CreateMap<Customer, CustomerModel>().ReverseMap();
                conf.CreateMap<Sitter, SitterModel>().ReverseMap();
                conf.CreateMap<Serviсe, ServiceModel>().ReverseMap();
                conf.CreateMap<WorkTime, WorkTimeModel>().ReverseMap();
                conf.CreateMap<Customer, CustomerModel>().ReverseMap();
                conf.CreateMap<Sitter, SitterModel>().ReverseMap();
                conf.CreateMap<Admin, AdminModel>().ReverseMap();
                conf.CreateMap<Contact, ContactModel>().ReverseMap();
                conf.CreateMap<ContactType, ContactTypeModel>().ReverseMap();
                conf.CreateMap<Contact, ContactModel>().ReverseMap();
                conf.CreateMap<ContactType, ContactTypeModel>().ReverseMap();
                conf.CreateMap<Dog, DogModel>().ReverseMap();
                conf.CreateMap<Passport, PassportModel>().ReverseMap();

            }));

        }
    }
}