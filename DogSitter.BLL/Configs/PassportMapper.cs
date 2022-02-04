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
    public class PassportMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitPassportMapper();
            }
            return _instance;
        }

        public static void InitPassportMapper()
        {
            _instance = new Mapper(new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<Passport, PassportModel>().ReverseMap();
                conf.CreateMap<Sitter, SitterModel>().ReverseMap();
            }));
        }
  
    }
}
