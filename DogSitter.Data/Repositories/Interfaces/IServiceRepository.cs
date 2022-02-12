using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IServiceRepository
    {
        void AddService(Serviсe service);
        List<Serviсe> GetAllServices();
        Serviсe GetServiceById(int id);
        void UpdateService(Serviсe service, bool IsDeleted);
        void UpdateService(Serviсe service);
    }
}