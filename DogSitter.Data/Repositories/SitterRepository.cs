using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using DogSitter.DAL.Repositories.Interfaces;

namespace DogSitter.DAL.Repositories
{
    public class SitterRepository : ISitterRepository
    {
        private DogSitterContext _context;

        public SitterRepository(DogSitterContext context)
        {
            _context = context;
        }

        public Sitter GetById(int id) =>
            _context.Sitters.FirstOrDefault(x => x.Id == id);

        public List<Sitter> GetAll() =>
            _context.Sitters.Where(d => d.IsDeleted).ToList();

        public void Add(Sitter sitter)
        {
            _context.Sitters.Add(sitter);
            _context.SaveChanges();
        }

        public void Update(Sitter sitter)
        {
            var entity = GetById(sitter.Id);
            entity.Passport = sitter.Passport;
            entity.FirstName = sitter.FirstName;
            entity.LastName = sitter.LastName;
            entity.Contacts = sitter.Contacts;
            entity.SubwayStation = sitter.SubwayStation;
            entity.Information = sitter.Information;
            entity.Services = sitter.Services;
            _context.SaveChanges();
        }

        public void Update(int id, bool isDeleted)
        {
            Sitter sitter = GetById(id);
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
        public Sitter Login(Contact contact, string pass)
        {
            if (contact != null && contact.Sitter != null)
            {
                if (contact.Sitter.Password == pass)
                {
                    return contact.Sitter;
                }
            }
            return null;
        }

        public List<Sitter> GetAllSitterByServiceId(int id) =>
            _context.Services.First(s => s.Id == id).Sitters.Where(s => !s.IsDeleted).ToList();

        public List<Sitter> GetAllSittersWithWorkTimeBySubwayStation(SubwayStation subwaystation) =>
            _context.Sitters.Where(s => s.SubwayStation.Id == subwaystation.Id && !s.IsDeleted)
            .Include(s => s.WorkTime).ToList();
    }
}
