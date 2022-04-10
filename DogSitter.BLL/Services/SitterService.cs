using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace DogSitter.BLL.Services
{
    public class SitterService : ISitterService
    {
        private readonly ISitterRepository _sitterRepository;
        private readonly ISubwayStationRepository _subwayStationRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<EmailSendller> _logger;
        private readonly IAdminRepository _adminRepository;

        public SitterService(ISitterRepository sitterRepository, ISubwayStationRepository subwayStationRepository,
            IMapper mapper, IUserRepository userRepository, ILogger<EmailSendller> logger, IAdminRepository adminRepository)
        {
            _sitterRepository = sitterRepository;
            _sitterRepository = sitterRepository;
            _subwayStationRepository = subwayStationRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
            _adminRepository = adminRepository;
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
            EmailSendller emailSendller = new EmailSendller(_logger);
            emailSendller.SendMessage(sitterModel, EmailMessage.SitterCreated, EmailTopic.ProfileCreated);

            var admins = _adminRepository.GetAllAdminWithContacts();
            var adminsModel = _mapper.Map<List<AdminModel>>(admins);

            foreach (var a in adminsModel)
            {
                emailSendller.SendMessage(a, EmailMessage.SitterCreatedForAdmin(id), EmailTopic.NewSitter);
            }

            return id;
        }

        public void Update(int id, SitterModel sitterModel)
        {
            var exitingSitter = _sitterRepository.GetById(id);
            if (exitingSitter is null)
            {
                throw new EntityNotFoundException($"Sitter was not found");
            }

            if (id != exitingSitter.Id)
            {
                throw new AccessException("Not enough rights");
            }

            var sitterToUpdate = _mapper.Map<Sitter>(sitterModel);
            var subwayStation = _subwayStationRepository.GetSubwayStationById(sitterModel.SubwayStation.Id);
            sitterToUpdate.SubwayStation = subwayStation;

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
            EmailSendller emailSendller = new EmailSendller(_logger);
            emailSendller.SendMessage(_mapper.Map<SitterModel>(entity), EmailMessage.ProfileDeleted, EmailTopic.ProfileDeleted);
        }

        public void Restore(int id)
        {
            var entity = _sitterRepository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            _sitterRepository.UpdateOrDelete(entity, false);

            EmailSendller emailSendller = new EmailSendller(_logger);
            emailSendller.SendMessage(_mapper.Map<SitterModel>(entity), EmailMessage.ProfileRestore, EmailTopic.Restore);
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
                EmailSendller emailSendller = new EmailSendller(_logger);
                emailSendller.SendMessage(_mapper.Map<SitterModel>(entity), EmailMessage.SitterVerified, EmailTopic.Verify);
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
            EmailSendller emailSendller = new EmailSendller(_logger);
            emailSendller.SendMessage(_mapper.Map<SitterModel>(entity), EmailMessage.SitterBlocked, EmailTopic.Block);
        }

        public List<SitterModel> GetAllSittersWithWorkTimeBySubwayStationId(int subwayStationId)
        {
            var subwayStation = _subwayStationRepository.GetSubwayStationById(subwayStationId);

            if (subwayStation is null)
                throw new EntityNotFoundException($"Subway station {subwayStation} was not found");

            return _mapper.Map<List<SitterModel>>(_sitterRepository
                .GetAllSittersWithWorkTimeBySubwayStationId(subwayStation.Id));
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
