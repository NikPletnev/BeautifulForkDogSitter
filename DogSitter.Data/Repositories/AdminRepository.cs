using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Repositories
{
    public class AdminRepository
    {
        private DogSitterContext _context;

        public AdminRepository()
        {
            _context = DogSitterContext.GetInstance();
        }

        public List<Admin> GetAllAdmins() =>
                     _context.Admins.Where(a => !a.IsDeleted).ToList();      

        public Admin GetAdminById(int id) =>
                     _context.Admins.FirstOrDefault(x => x.Id == id);

        public void AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }

        public void DeleteAdmin(int id)
        {
            Admin admin = GetAdminById(id);

            foreach (var c in admin.Contacts)
            {
                _context.Contacts.Remove(c);
            }

            _context.Admins.Remove(admin);
            _context.SaveChanges();
        }

        public void UpdateAdmin(Admin admin)
        {
            var entity = GetAdminById(admin.Id);
            entity.FirstName = admin.FirstName;
            entity.LastName = admin.LastName;
            entity.Password = admin.Password;
            entity.Contacts = admin.Contacts;
            _context.SaveChanges();
        }

        public void UpdateAdmin(int id, bool isDeleted)
        {
            var entity = GetAdminById(id);          
            entity.IsDeleted = isDeleted;
            _context.SaveChanges();
        }

    }
}
