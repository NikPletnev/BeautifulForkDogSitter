using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface ISubwayStationService
    {
        int AddSubwayStation(SubwayStationModel subwayStationModel);
        void DeleteSubwayStation(int id);
        List<SubwayStationModel> GetAllSubwayStations();
        List<SubwayStationModel> GetAllSubwayStationsWhereSitterExist();
        SubwayStationModel GetSubwayStationById(int id);
        void RestoreSubwayStation(int id);
        void UpdateSubwayStation(int id, SubwayStationModel subwayStationModel);
    }
}