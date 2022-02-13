using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class SitterRepository
    {
        private DogSitterContext _context;

        public SitterRepository()
        {
            _context = DogSitterContext.GetInstance();
        }

        public Sitter GetSitterById(int id) =>
            _context.Sitters.FirstOrDefault(x => x.Id == id);

        public List<Sitter> GetAllSitters() =>
            _context.Sitters.Where(d => d.IsDeleted).ToList();

        public void AddSitter(Sitter sitter)
        {
            _context.Sitters.Add(sitter);
            _context.SaveChanges();
        }

        public void UpdateSitter(Sitter sitter)
        {
            var entity = GetSitterById(sitter.Id);
            entity.Passport = sitter.Passport;
            entity.FirstName = sitter.FirstName;
            entity.LastName = sitter.LastName;
            entity.Contacts = sitter.Contacts;
            entity.SubwayStation = sitter.SubwayStation;
            entity.Information = sitter.Information;
            entity.Services = sitter.Services;
            _context.SaveChanges();
        }

        public void UpdateSitter(int id, bool isDeleted)
        {
            Sitter sitter = GetSitterById(id);
            sitter.IsDeleted = isDeleted;
            _context.SaveChanges();
        }
    }
}
