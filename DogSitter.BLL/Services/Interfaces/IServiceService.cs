using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IServiceService
    {
        void AddService(ServiceModel serviceModel);
        List<ServiceModel> GetAllServices();
        ServiceModel GetServiceById(int id);
        void RestoreService(int id);
        void UpdateService(int id);
        void UpdateService(ServiceModel serviceModel);
    }
}