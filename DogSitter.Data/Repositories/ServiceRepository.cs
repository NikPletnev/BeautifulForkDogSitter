using DogSitter.DAL.Entity;

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

        public int AddService(Serviсe service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();

            return service.Id;
        }

        public void UpdateService(Serviсe exitingServiсe, Serviсe serviceToUpdate)
        {
            exitingServiсe.Name = serviceToUpdate.Name;
            exitingServiсe.Price = serviceToUpdate.Price;
            exitingServiсe.Description = serviceToUpdate.Description;
            exitingServiсe.DurationHours = serviceToUpdate.DurationHours;
            _context.SaveChanges();
        }

        public void UpdateOrDeleteService(Serviсe service, bool IsDeleted)
        {
            service.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }

        public List<Serviсe> GetAllServicesBySitterId(int id) =>
            _context.Sitters.First(s => s.Id == id).Services.Where(s => !s.IsDeleted).ToList();


    }
}
