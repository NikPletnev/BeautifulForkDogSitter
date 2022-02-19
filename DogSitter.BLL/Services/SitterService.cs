using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class SitterService : ISitterService
    {
        private ISitterRepository _repository;
        private ISubwayStationRepository _subwayStationRepository;

        private IMapper _mapper;

        public SitterService(ISitterRepository sitterRepository, 
            ISubwayStationRepository subwayStationRepository, IMapper mapper)
        {
            _repository = sitterRepository;
            _subwayStationRepository = subwayStationRepository;
            _mapper = mapper;
        }

        public SitterModel GetById(int id)
        {
            var sitter = _repository.GetById(id);
            if (sitter == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }                     
            
            return _mapper.Map<SitterModel>(sitter);
        }
        public List<SitterModel> GetAll()
        {
            var sitters = _repository.GetAll();
            return _mapper.Map<List<SitterModel>>(sitters);
        }

        public void Add(SitterModel sitterModel)
        {
            var sitter = _mapper.Map<Sitter>(sitterModel);
            _repository.Add(sitter);
        }

        public void Update(SitterModel sitterModel)
        {
            var sitter = _mapper.Map<Sitter>(sitterModel);
            var entity = _repository.GetById(sitterModel.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {sitterModel.Id} was not found");
            }
            _repository.Update(sitter);
        }

        public void DeleteById(int id)
        { 
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            bool delete = true;
            _repository.Update(id, delete);
            _repository.EditProfileStateBySitterId(id, false);
        }

        public void Restore(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            _repository.Update(id, false);
        }

        public void ConfirmProfileSitterById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            if (!entity.IsDeleted)
            {
                _repository.EditProfileStateBySitterId(id, true);
            }
        }

        public void BlockProfileSitterById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            _repository.EditProfileStateBySitterId(id, false);
        }

        public List<SitterModel> GetAllSittersWithWorkTimeBySubwayStation(SubwayStationModel subwayStationModel)
        {
            var subwayStation = _subwayStationRepository.GetSubwayStationById(subwayStationModel.Id);

            if (subwayStation is null)
                throw new EntityNotFoundException($"Subway station {subwayStation} was not found");

            return _mapper.Map<List<SitterModel>>(_repository
                .GetAllSittersWithWorkTimeBySubwayStation(subwayStation));
        }
    }
}
