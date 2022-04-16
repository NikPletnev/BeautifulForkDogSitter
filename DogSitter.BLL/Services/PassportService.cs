using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class PassportService : IPassportService
    {
        private readonly IPassportRepository _rep;
        private readonly IMapper _map;

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

            var passport = _map.Map<Passport>(passportModel);

            passport.FirstName = Crypter.Encrypt(passport.FirstName);
            passport.LastName = Crypter.Encrypt(passport.LastName);
            passport.Seria = Crypter.Encrypt(passport.Seria);
            passport.Number = Crypter.Encrypt(passport.Number);
            passport.Division = Crypter.Encrypt(passport.Division);
            passport.DivisionCode = Crypter.Encrypt(passport.DivisionCode);
            passport.Registration = Crypter.Encrypt(passport.Registration);

            var entity = _rep.GetPassportById(id);

            if (entity == null)
            {
                throw new EntityNotFoundException($"Passport {id} was not found");
            }

            _rep.UpdatePassport(entity, passport);
        }



    }
}
