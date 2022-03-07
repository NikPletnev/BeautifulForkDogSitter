using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class SitterService : ISitterService
    {
        private ISitterRepository _sitterRepository;
        private ISubwayStationRepository _subwayStationRepository;
        private IMapper _mapper;
        private IUserRepository _userRepository;

        public SitterService(ISitterRepository sitterRepository, ISubwayStationRepository subwayStationRepository,
            IMapper mapper, IUserRepository userRepository)
        {
            _sitterRepository = sitterRepository;
            _sitterRepository = sitterRepository;
            _subwayStationRepository = subwayStationRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public SitterModel GetById(int id)
        {
            var sitter = _sitterRepository.GetById(id);
            if (sitter == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            sitter.Passport.FirstName = Crypter.Decrypt(sitter.Passport.FirstName);
            sitter.Passport.LastName = Crypter.Decrypt(sitter.Passport.LastName);
            sitter.Passport.Seria = Crypter.Decrypt(sitter.Passport.Seria);
            sitter.Passport.Number = Crypter.Decrypt(sitter.Passport.Number);
            sitter.Passport.Division = Crypter.Decrypt(sitter.Passport.Division);
            sitter.Passport.DivisionCode = Crypter.Decrypt(sitter.Passport.DivisionCode);
            sitter.Passport.Registration = Crypter.Decrypt(sitter.Passport.Registration);
            return _mapper.Map<SitterModel>(sitter);
        }

        public List<SitterModel> GetAll()
        {
            var sitters = _sitterRepository.GetAll();
            return _mapper.Map<List<SitterModel>>(sitters);
        }

        public int Add(SitterModel sitterModel)
        {
            var sitter = _mapper.Map<Sitter>(sitterModel);
            var subwayStation = _subwayStationRepository.GetSubwayStationById(sitterModel.SubwayStation.Id);

            sitter.SubwayStation = subwayStation;
            sitter.Role = Role.Sitter;
            sitter.Password = PasswordHash.HashPassword(sitter.Password);
            sitter.Passport.FirstName = Crypter.Encrypt(sitter.Passport.FirstName);
            sitter.Passport.LastName = Crypter.Encrypt(sitter.Passport.LastName);
            sitter.Passport.Seria = Crypter.Encrypt(sitter.Passport.Seria);
            sitter.Passport.Number = Crypter.Encrypt(sitter.Passport.Number);
            sitter.Passport.Division = Crypter.Encrypt(sitter.Passport.Division);
            sitter.Passport.DivisionCode = Crypter.Encrypt(sitter.Passport.DivisionCode);
            sitter.Passport.Registration = Crypter.Encrypt(sitter.Passport.Registration);

            var id = _sitterRepository.Add(sitter);
            return id;
        }

        public void Update(int id, SitterModel sitterModel)
        {
            var exitingSitter = _sitterRepository.GetById(id);

            if (id != exitingSitter.Id)
            {
                throw new AccessException("Not enough rights");
            }
            var sitterToUpdate = _mapper.Map<Sitter>(sitterModel);

            if (exitingSitter is null)
            {
                throw new EntityNotFoundException($"Sitter {sitterModel.Id} was not found");
            }
            _sitterRepository.Update(exitingSitter, sitterToUpdate);
        }

        public void DeleteById(int userId, int id)
        {
            var entity = _sitterRepository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            if (_userRepository.GetUserById(userId).Role != Role.Admin && userId != id)
            {
                throw new AccessException("Not enough rights");
            }

            _sitterRepository.UpdateOrDelete(entity, true);
            _sitterRepository.EditProfileStateBySitterId(id, false);
        }

        public void Restore(int id)
        {
            var entity = _sitterRepository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            _sitterRepository.UpdateOrDelete(entity, false);
        }

        public void ConfirmProfileSitterById(int id)
        {
            var entity = _sitterRepository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            if (!entity.IsDeleted)
            {
                _sitterRepository.EditProfileStateBySitterId(id, true);
            }
        }

        public void BlockProfileSitterById(int id)
        {
            var entity = _sitterRepository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            _sitterRepository.EditProfileStateBySitterId(id, false);
        }

        //public List<SitterModel> GetAllSitterByServiceId(int id)
        //{
        //    var service = _serviceRepository.GetServiceById(id);

        //    if (service is null)
        //        throw new EntityNotFoundException($"Service {id} was not found");

        //    return _mapper.Map<List<SitterModel>>(_sitterRepository.GetAllSitterByServiceId(id));
        //}

        public List<SitterModel> GetAllSittersWithWorkTimeBySubwayStation(SubwayStationModel subwayStationModel)
        {
            var subwayStation = _subwayStationRepository.GetSubwayStationById(subwayStationModel.Id);

            if (subwayStation is null)
                throw new EntityNotFoundException($"Subway station {subwayStation} was not found");

            return _mapper.Map<List<SitterModel>>(_sitterRepository
                .GetAllSittersWithWorkTimeBySubwayStation(subwayStation));
        }

        public List<SitterModel> GetAllSittersWithServices()
        {
            var sitters = _sitterRepository.GetAllSitterWithService();

            if (sitters == null)
            {
                throw new EntityNotFoundException($"Sitters was not found");
            }

            return _mapper.Map<List<SitterModel>>(sitters);
        }
    }
}
