﻿using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DogSitter.BLL.Config
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
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerModel>().ReverseMap();
                cfg.CreateMap<Sitter, SitterModel>().ReverseMap();
                cfg.CreateMap<Comment, CommentModel>().ReverseMap();

            }));

        }
    }
}