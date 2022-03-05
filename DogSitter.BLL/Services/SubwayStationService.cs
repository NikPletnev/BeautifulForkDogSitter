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
                throw new EntityNotFoundException($"Subway station wasn't found");

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

        public int AddSubwayStation(SubwayStationModel subwayStationModel)
        {
            var subwayStation = _mapper.Map<SubwayStation>(subwayStationModel);

            return _subwayStationRepository.AddSubwayStation(subwayStation);
        }

        public void UpdateSubwayStation(int id, SubwayStationModel subwayStationModel)
        {
            var subwayStationToUpdate = _mapper.Map<SubwayStation>(subwayStationModel);

            var exitingSubwayStation = _subwayStationRepository.GetSubwayStationById(id);

            if (exitingSubwayStation is null)
                throw new EntityNotFoundException("Subway station wasn't found");

            _subwayStationRepository.UpdateSubwayStation(exitingSubwayStation, subwayStationToUpdate);
        }

        public void DeleteSubwayStation(int id)
        {
            var subwayStationToDelete = _subwayStationRepository.GetSubwayStationById(id);
            if (subwayStationToDelete is null)
                throw new EntityNotFoundException("Subway station wasn't found");

            _subwayStationRepository.UpdateOrDeleteSubwayStation(subwayStationToDelete, true);
        }

        public void RestoreSubwayStation(int id)
        {
            var subwayStationToRestore = _subwayStationRepository.GetSubwayStationById(id);

            if (subwayStationToRestore is null)
                throw new EntityNotFoundException("Subway station wasn't found");

            _subwayStationRepository.UpdateOrDeleteSubwayStation(subwayStationToRestore, false);
        }
    }
}
