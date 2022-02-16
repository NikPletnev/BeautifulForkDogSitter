using AutoMapper;
using DogSitter.BLL.Exeptions;
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
            if (passportModel.FirstName == String.Empty ||
                passportModel.LastName == String.Empty ||
                passportModel.Seria == String.Empty ||
                passportModel.Number == String.Empty ||
                passportModel.Division == String.Empty ||
                passportModel.DivisionCode == String.Empty)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to edit the passport {id}");
            }

            var entity = _map.Map<Passport>(passportModel);
            var passport = _rep.GetPassportById(id);

            if (passport == null)
            {
                throw new EntityNotFoundException($"Passport {id} was not found");
            }

            _rep.UpdatePassport(entity);
        }

        public void AddPassport(PassportModel passportModel)
        {
            if (passportModel.FirstName == String.Empty ||
                passportModel.LastName == String.Empty ||
                passportModel.Seria == String.Empty ||
                passportModel.Number == String.Empty ||
                passportModel.Division == String.Empty ||
                passportModel.DivisionCode == String.Empty)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to add new passport");
            }

            _rep.AddPassport(_map.Map<Passport>(passportModel));
        }

        public PassportModel GetPassportById(int id)
        {
            var passport = _rep.GetPassportById(id);
            if (passport == null)
            {
                throw new EntityNotFoundException($"Passport {id} was not found");
            }
            return _map.Map<PassportModel>(passport);
        }

    }
}
