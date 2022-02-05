using DogSitter.BLL.Models;

namespace DogService.BLL.Services
{
    public interface IServiceService
    {
        void AddService(ServiceModel serviceModel);
        void DeleteService(int id);
        List<ServiceModel> GetAllServices();
        ServiceModel GetServiceById(int id);
        void RestoreService(int id);
        void UpdateService(int id, ServiceModel serviceModel);
        void UpdateService(ServiceModel serviceModel);
    }
}