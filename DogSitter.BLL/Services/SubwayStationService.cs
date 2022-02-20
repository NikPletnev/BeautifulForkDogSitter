using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class SubwayStationService : ISubwayStationService
    {
        private readonly ISubwayStationRepository _subwayStationRepository;
        private readonly IMapper _mapper;

        public SubwayStationService(ISubwayStationRepository subwayStationRepository, IMapper mapper)
        {
            _subwayStationRepository = subwayStationRepository;
            _mapper = mapper;
        }

        public SubwayStationModel GetSubwayStationById(int id)
        {
            var subwayStation = _subwayStationRepository.GetSubwayStationById(id);

            if (subwayStation is null)
                throw new EntityNotFoundException($"{subwayStation} c Id = {id} не найдена!");

            return _mapper.Map<SubwayStationModel>(subwayStation);
        }

        public List<SubwayStationModel> GetAllSubwayStations()
        {
            var subwayStations = _subwayStationRepository.GetAllSubwayStations();
            return _mapper.Map<List<SubwayStationModel>>(subwayStations);
        }

        public List<SubwayStationModel> GetAllSubwayStationsWhereSitterExist()
        {
            var subwayStationsWithExitingSitter = _subwayStationRepository
                .GetAllSubwayStationsWhereSitterExist();
            return _mapper.Map<List<SubwayStationModel>>(subwayStationsWithExitingSitter);
        }

        public void AddSubwayStation(SubwayStationModel subwayStationModel)
        {
            var subwayStation = _mapper.Map<SubwayStation>(subwayStationModel);

            _subwayStationRepository.AddSubwayStation(subwayStation);
        }

        public void UpdateSubwayStation(SubwayStationModel subwayStationModel)
        {
            var exitingSubwayStation = _mapper.Map<SubwayStation>(subwayStationModel);

            if (_subwayStationRepository.GetSubwayStationById(exitingSubwayStation.Id) is null)
                throw new EntityNotFoundException($"{exitingSubwayStation} не найдена!");

            var subwayStationToUpdate = _mapper.Map<SubwayStation>(exitingSubwayStation);

            _subwayStationRepository.UpdateSubwayStation(exitingSubwayStation, subwayStationToUpdate);
        }

        public void DeleteSubwayStation(SubwayStationModel subwayStationModel)
        {
            var subwayStation = _mapper.Map<SubwayStation>(subwayStationModel);

            if (_subwayStationRepository.GetSubwayStationById(subwayStation.Id) is null)
                throw new EntityNotFoundException($"{subwayStation} не найдена!");

            _subwayStationRepository.UpdateOrDeleteSubwayStation(subwayStation, true);
        }

        public void RestoreSubwayStation(SubwayStationModel subwayStationModel)
        {
            var subwayStation = _mapper.Map<SubwayStation>(subwayStationModel);

            if (_subwayStationRepository.GetSubwayStationById(subwayStation.Id) is null)
                throw new EntityNotFoundException($"{subwayStation} не найдена!");

            _subwayStationRepository.UpdateOrDeleteSubwayStation(subwayStation, false);
        }
    }
}
