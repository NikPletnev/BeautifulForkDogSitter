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

            var passport = _map.Map<Passport>(passportModel);
            var entity = _rep.GetPassportById(id);

            if (entity == null)
            {
                throw new EntityNotFoundException($"Passport {id} was not found");
            }

            _rep.UpdatePassport(entity, passport);
        }

        

    }
}
