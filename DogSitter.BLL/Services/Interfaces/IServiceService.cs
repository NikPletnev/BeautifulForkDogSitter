using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IServiceService
    {
        void AddService(ServiceModel serviceModel);
        List<ServiceModel> GetAllServices();
        List<ServiceModel> GetAllServicesBySitterId(int id);
        ServiceModel GetServiceById(int id);
        void DeleteService(int id);
        void UpdateService(int id, ServiceModel serviceModel);
        void RestoreService(int id);
    }
}