using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IServiceService
    {
        int AddService(int userId, ServiceModel serviceModel);
        List<ServiceModel> GetAllServices();
        List<ServiceModel> GetAllServicesBySitterId(int userId, int id);
        ServiceModel GetServiceById(int id);
        void DeleteService(int userId, int id);
        void UpdateService(int userId, int id, ServiceModel serviceModel);
        void RestoreService(int id);
    }
}