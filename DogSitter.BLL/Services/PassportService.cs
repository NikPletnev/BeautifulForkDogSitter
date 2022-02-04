using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class PassportService
    {
        private PassportRepository _rep;

        public PassportService()
        {
            _rep = new PassportRepository();
        }

        public void UpdatePassport(int id, PassportModel passportModel)
        {
            var entity = CustomMapper.GetInstance().Map<Passport>(passportModel);
            var passport = _rep.GetPassportById(id);
            if (passport == null)
            {
                throw new Exception("Паспорт не найден");
            }
            _rep.UpdatePassport(entity);

        }

        public void AddPassport(PassportModel passportModel)
        {
            _rep.AddPassport(CustomMapper.GetInstance().Map<Passport>(passportModel));
        }

        public PassportModel GetPassportById(int id)
        {
            var passport = _rep.GetPassportById(id);
            if (passport == null)
            {
                throw new Exception("Паспорт не найден");
            }
            return CustomMapper.GetInstance().Map<PassportModel>(passport);
        }

    }
}
