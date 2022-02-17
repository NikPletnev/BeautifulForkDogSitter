using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface ISubwayStationService
    {
        void AddSubwayStation(SubwayStationModel subwayStationModel);
        void DeleteSubwayStation(SubwayStationModel subwayStationModel);
        List<SubwayStationModel> GetAllSubwayStations();
        List<SubwayStationModel> GetAllSubwayStationsWhereSitterExist();
        SubwayStationModel GetSubwayStationById(int id);
        void RestoreSubwayStation(SubwayStationModel subwayStationModel);
        void UpdateSubwayStation(SubwayStationModel subwayStationModel);
    }
}