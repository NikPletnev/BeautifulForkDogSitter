using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface ISubwayStationRepository
    {
        void AddSubwayStation(SubwayStation subwayStation);
        List<SubwayStation> GetAllSubwayStations();
        List<SubwayStation> GetAllSubwayStationsWhereSitterExist();
        SubwayStation GetSubwayStationById(int id);
        void RestoreSubwayStation(SubwayStation subwayStation, bool IsDeleted);
        void UpdateSubwayStation(SubwayStation subwayStation);
        void UpdateSubwayStation(SubwayStation subwayStation, bool IsDeleted);
    }
}