using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface ISitterService
    {
        int Add(SitterModel sitterModel);
        void BlockProfileSitterById(int id);
        void ConfirmProfileSitterById(int id);
        void DeleteById(int userId, int id);
        List<SitterModel> GetAll();
        //List<SitterModel> GetAllSitterByServiceId(int id);
        List<SitterModel> GetAllSittersWithWorkTimeBySubwayStation(SubwayStationModel subwayStationModel);
        SitterModel GetById(int id);
        void Restore(int id);
        void Update(int id, SitterModel sitterModel);
        List<SitterModel> GetAllSittersWithServices();
    }
}