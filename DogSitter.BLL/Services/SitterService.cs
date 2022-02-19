using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class SitterService : ISitterService
    {
        private ISitterRepository _sitterRepository;
        private ISubwayStationRepository _subwayStationRepository;

        private IMapper _mapper;

        public SitterService(ISitterRepository sitterRepository, 
            ISubwayStationRepository subwayStationRepository, IMapper mapper)
        {
            _sitterRepository = sitterRepository;
            _subwayStationRepository = subwayStationRepository;
            _mapper = mapper;
        }

        public SitterModel GetById(int id)
        {
            try
            {
                var sitter = _sitterRepository.GetById(id);
                return _mapper.Map<SitterModel>(sitter);
            }
            catch (Exception)
            {

                throw new Exception("Ситтер не найден");
            }
        }
        public List<SitterModel> GetAll()
        {
            var sitters = _sitterRepository.GetAll();
            return _mapper.Map<List<SitterModel>>(sitters);
        }

        public void Add(SitterModel sitterModel)
        {
            var sitter = _mapper.Map<Sitter>(sitterModel);
            _sitterRepository.Add(sitter);
        }

        public void Update(SitterModel sitterModel)
        {
            var sitter = _mapper.Map<Sitter>(sitterModel);
            var entity = _repository.GetById(sitterModel.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {sitterModel.Id} was not found");
            }
            _sitterRepository.Update(sitter);
        }

        public void DeleteById(int id)
        { 
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            bool delete = true;
            _sitterRepository.Update(id, delete);
            _sitterRepository.EditProfileStateBySitterId(id, false);
        }

        public void Restore(int id)
        {  
            bool Delete = false;
            _sitterRepository.Update(id, Delete);
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

        public List<SitterModel> GetAllSittersWithWorkTimeBySubwayStation(SubwayStationModel subwayStationModel)
        {
            var subwayStation = _subwayStationRepository.GetSubwayStationById(subwayStationModel.Id);

            if (subwayStation is null)
                throw new EntityNotFoundException($"Subway station {subwayStation} was not found");

            return _mapper.Map<List<SitterModel>>(_sitterRepository
                .GetAllSittersWithWorkTimeBySubwayStation(subwayStation));
        }
    }
}
