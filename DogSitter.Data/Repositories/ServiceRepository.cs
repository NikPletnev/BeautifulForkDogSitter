using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DogSitterContext _context;
        private bool _isInitialized;
        public ServiceRepository(DogSitterContext dbContext)
        {
            _isInitialized = true;
            _context = dbContext;
        }

        public List<Serviсe> GetAllServices() =>
            _context.Services.Where(s => !s.IsDeleted).ToList();

        public Serviсe GetServiceById(int id) =>
            _context.Services.FirstOrDefault(s => s.Id == id);

        public void AddService(Serviсe service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void UpdateService(Serviсe service)
        {
            _context.Entry(service).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateService(Serviсe service, bool IsDeleted)
        {
            service.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
        public void RestoreService(Serviсe service, bool IsDeleted)
        {
            service.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}
