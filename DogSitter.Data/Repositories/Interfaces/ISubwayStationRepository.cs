using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface ISubwayStationRepository
    {
        int AddSubwayStation(SubwayStation subwayStation);
        List<SubwayStation> GetAllSubwayStations();
        List<SubwayStation> GetAllSubwayStationsWhereSitterExist();
        SubwayStation GetSubwayStationById(int id);
        void UpdateSubwayStation(SubwayStation exitingSubwayStation, SubwayStation subwayStationToUodate);
        void UpdateOrDeleteSubwayStation(SubwayStation subwayStation, bool IsDeleted);
    }
}