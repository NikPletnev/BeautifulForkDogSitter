using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private DogSitterContext _context;

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

        public Admin Login(Contact contact, string pass)
        {
            if (contact != null && contact.Admin != null)
            {
                if (contact.Admin.Password == pass)
                {
                    return contact.Admin;
                }
            }
            return null;
        }

    }
}
