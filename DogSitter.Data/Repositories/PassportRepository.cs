using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class PassportRepository : IPassportRepository
    {
        private DogSitterContext _context;

        public PassportRepository(DogSitterContext context)
        {
            _context = context;
        }

        public Passport GetPassportById(int id) =>
                         _context.Passports.FirstOrDefault(x => x.Id == id);


        public void AddPassport(Passport passport)
        {
            _context.Passports.Add(passport);
            _context.SaveChanges();
        }

        public void UpdatePassport(Passport entity, Passport passport)
        {
            entity.FirstName = passport.FirstName;
            entity.LastName = passport.LastName;
            entity.DateOfBirth = passport.DateOfBirth;
            entity.Seria = passport.Seria;
            entity.Number = passport.Number;
            entity.Division = passport.Division;
            entity.DivisionCode = passport.DivisionCode;
            entity.IssueDate = passport.IssueDate;
            entity.Registration = passport.Registration;
            _context.SaveChanges();
        }
    }
}
