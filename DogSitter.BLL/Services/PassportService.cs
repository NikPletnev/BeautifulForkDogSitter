using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class PassportService : IPassportService
    {
        private readonly IPassportRepository _rep;
        private IMapper _map;

        public PassportService(IPassportRepository passportRepository, IMapper mapper)
        {
            _rep = passportRepository;
            _map = mapper;
        }

        public void UpdatePassport(int id, PassportModel passportModel)
        {
            var entity = _map.Map<Passport>(passportModel);
            var passport = _rep.GetPassportById(id);
            if (passport == null)
            {
                throw new Exception("Паспорт не найден");
            }
            _rep.UpdatePassport(entity);

        }

        public void AddPassport(PassportModel passportModel)
        {
            _rep.AddPassport(_map.Map<Passport>(passportModel));
        }

        public PassportModel GetPassportById(int id)
        {
            var passport = _rep.GetPassportById(id);
            if (passport == null)
            {
                throw new Exception("Паспорт не найден");
            }
            return _map.Map<PassportModel>(passport);
        }

    }
}
