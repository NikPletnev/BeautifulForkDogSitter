using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Repositories
{
    public class PassportRepository
    {
        private DogSitterContext _context;

        public PassportRepository()
        {
            _context = DogSitterContext.GetInstance();
        }
  

        public Passport GetPassportById(int id) =>
                         _context.Passports.FirstOrDefault(x => x.Id == id);
        

        public void AddPassport(Passport passport)
        {
            _context.Passports.Add(passport);
            _context.SaveChanges();
        }

        public void UpdatePassport(Passport passport)
        {
            var entity = GetPassportById(passport.Id);
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
