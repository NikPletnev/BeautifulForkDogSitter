using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Services
{
    public class PassportService
    {
        private PassportRepository _rep = new PassportRepository();
        private MMapper _map = new MMapper();

        public void UpdatePassport(int id, PassportModel passportModel)
        {
            var passport = _rep.GetPassportById(id);
            if (passport == null)
            {
                throw new Exception("Паспорт не найден");
            }
            _rep.UpdatePassport(_map.MapPassportModelToPassport(passportModel));          
            
        }

        public void AddPassport(PassportModel passportModel)
        {     
            _rep.AddPassport(_map.MapPassportModelToPassport(passportModel));
        }

        public PassportModel GetPassporBbyId(int id)
        {
            var passport = _rep.GetPassportById(id);
            if (passport == null)
            {
                throw new Exception("Паспорт не найден");
            }
            return _map.MapPassportToPassportModel(passport);
        }

    }
}
