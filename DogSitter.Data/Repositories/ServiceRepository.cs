using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DogSitterContext _context;

        public ServiceRepository(DogSitterContext context)
        {
            _context = context;
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
            var trackingService = _context.ChangeTracker.Entries<Serviсe>()
                .First(a => a.Entity.Id == service.Id).Entity;

            trackingService.Name = service.Name;
            trackingService.Price = service.Price;
            trackingService.Description = service.Description;
            trackingService.DurationHours = service.DurationHours;
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

        public List<Serviсe> GetAllServicesBySitterId(int id) =>
            _context.Sitters.First(s => s.Id == id).Services.Where(s => !s.IsDeleted).ToList();
    }
}
