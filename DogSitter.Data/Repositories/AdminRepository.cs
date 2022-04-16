using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DogSitterContext _context;

        public AdminRepository(DogSitterContext context)
        {
            _context = context;
        }

        public List<Admin> GetAllAdmins() =>
                     _context.Admins.Where(a => !a.IsDeleted).ToList();

        public List<Admin> GetAllAdminWithContacts() =>
            _context.Admins.Include(a => a.Contacts.Where(c => !c.IsDeleted)).Where(a => !a.IsDeleted).ToList();

        public Admin GetAdminById(int id) =>
                     _context.Admins.FirstOrDefault(x => x.Id == id);

        public Admin GetAdminByIdWithContacts(int id) =>
            _context.Admins.Include(a => a.Contacts.Where(c => !c.IsDeleted)).FirstOrDefault(a => a.Id == id);

        public void AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }

        public void UpdateAdmin(Admin admin, Admin entity)
        {
            entity.FirstName = admin.FirstName;
            entity.LastName = admin.LastName;
            entity.Password = admin.Password;
            entity.Contacts = admin.Contacts;
            _context.SaveChanges();
        }

        public void UpdateAdmin(Admin admin, bool isDeleted)
        {
            admin.IsDeleted = isDeleted;
            _context.SaveChanges();
        }

    }
}
