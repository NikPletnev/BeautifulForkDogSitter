using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IServiceRepository
    {
        int AddService(Serviсe service);
        List<Serviсe> GetAllServices();
        List<Serviсe> GetAllServicesBySitterId(int id);
        Serviсe GetServiceById(int id);
        void UpdateService(Serviсe exitingServiсe, Serviсe serviceToUpdate);
        void UpdateOrDeleteService(Serviсe service, bool isDeleted);
    }
}