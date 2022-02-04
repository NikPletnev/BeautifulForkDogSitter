using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class ServiceRepository
    {
        private readonly DogSitterContext _context;

        public ServiceRepository()
        {
            _context = DogSitterContext.GetInstance();
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

        public void DeleteService(int id)
        {
            var service = GetServiceById(id);
            _context.Services.Remove(service);
            _context.SaveChanges();
        }

        public void UpdateService(Serviсe service)
        {
            var entity = GetServiceById(service.Id);
            entity.Name = service.Name;
            entity.Price = service.Price;
            entity.Description = service.Description;
            entity.DurationHours = service.DurationHours;
            _context.SaveChanges();
        }

        public void UpdateService(int id, bool IsDeleted)
        {
            var entity = GetServiceById(id);
            entity.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}
