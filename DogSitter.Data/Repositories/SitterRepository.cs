using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class SitterRepository : ISitterRepository
    {
        private readonly DogSitterContext _context;

        public SitterRepository(DogSitterContext context)
        {
            _context = context;
        }

        public Sitter GetById(int id)
        {
            var sitter = _context.Sitters.Where(x => x.Id == id)
            .Include(w => w.Customers)
            .Include(w => w.Orders)
            .Include(w => w.Services)
            .Include(w => w.Timesheets)
            .Include(w => w.BusyTime)
            .Include(w => w.Passport)
            .Include(w => w.Contacts)
            .FirstOrDefault();
            return sitter;
        }


        public List<Sitter> GetAll() =>
            _context.Sitters.Where(d => !d.IsDeleted)
            .Include(w => w.Customers)
            .Include(w => w.Orders)
            .Include(w => w.Services)
            .Include(w => w.Timesheets)
            .Include(w => w.BusyTime)
            .Include(w => w.Passport)
            .Include(w => w.Contacts)
            .ToList();

        public int Add(Sitter sitter)
        {
            var entity = _context.Sitters.Add(sitter);
            _context.SaveChanges();
            return entity.Entity.Id;
        }

        public void Update(Sitter exitingSitter, Sitter sitterToUpdate)
        {
            exitingSitter.FirstName = sitterToUpdate.FirstName;
            exitingSitter.LastName = sitterToUpdate.LastName;
            exitingSitter.SubwayStation = sitterToUpdate.SubwayStation;
            exitingSitter.Information = sitterToUpdate.Information;
            _context.SaveChanges();
        }

        public void UpdateOrDelete(Sitter sitter, bool isDeleted)
        {
            sitter.IsDeleted = isDeleted;
            _context.SaveChanges();
        }

        public void EditProfileStateBySitterId(int id, bool verify)
        {
            var entity = GetById(id);
            if (!entity.IsDeleted)
            {
                entity.Verified = verify;
                _context.SaveChanges();
            }
        }

        public List<Sitter> GetAllSittersWithTimesheetsBySubwayStationId(int subwaystationId) =>
            _context.Sitters.Where(s => s.SubwayStation.Id == subwaystationId && !s.IsDeleted)
            .Include(w => w.Timesheets)
            .ToList();

        public void ChangeRating(Sitter sitter)
        {
            var entity = GetById(sitter.Id);
            entity.Rating = sitter.Rating;
            _context.SaveChanges();
        }

        public List<Order> GetAllSitterOrders(Sitter sitter)
        {
            return _context.Orders.Where(d => d.Sitter.Id == sitter.Id && !d.IsDeleted && d.Status == Enums.Status.Completed).ToList();
        }

        public List<Sitter> GetAllSitterWithService() =>
           _context.Sitters.Where(s => !s.IsDeleted).Include(s => s.Services.Where(c => !c.IsDeleted)).ToList();
    }
}
