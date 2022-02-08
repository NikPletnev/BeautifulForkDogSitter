using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class PassportService : IPassportService
    {
        private PassportRepository _rep;
        private IMapper _mapper;

        public PassportService(IMapper mapper)
        {
            _rep = new PassportRepository();
            _mapper = mapper;
        }

        public void UpdatePassport(int id, PassportModel passportModel)
        {
            var entity = _mapper.Map<Passport>(passportModel);
            var passport = _rep.GetPassportById(id);
            if (passport == null)
            {
                throw new Exception("Паспорт не найден");
            }
            _rep.UpdatePassport(entity);

        }

        public void AddPassport(PassportModel passportModel)
        {
            _rep.AddPassport(_mapper.Map<Passport>(passportModel));
        }

        public PassportModel GetPassportById(int id)
        {
            var passport = _rep.GetPassportById(id);
            if (passport == null)
            {
                throw new Exception("Паспорт не найден");
            }
            return _mapper.Map<PassportModel>(passport);
        }

    }
}
