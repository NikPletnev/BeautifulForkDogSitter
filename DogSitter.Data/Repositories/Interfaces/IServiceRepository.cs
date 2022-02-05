using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IServiceRepository
    {
        void AddService(Serviсe service);
        void DeleteService(int id);
        List<Serviсe> GetAllServices();
        Serviсe GetServiceById(int id);
        void UpdateService(int id, bool IsDeleted);
        void UpdateService(Serviсe service);
    }
}