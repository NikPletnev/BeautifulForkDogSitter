using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IAdminRepository
    {
        void AddAdmin(Admin admin);
        Admin GetAdminById(int id);
        List<Admin> GetAllAdmins();
        void UpdateAdmin(Admin admin, Admin entity);
        void UpdateAdmin(Admin admin, bool isDeleted);
        Admin Login(Contact contact, string pass);
        List<Admin> GetAllAdminWithContacts();
        Admin GetAdminByIdWithContacts(int id);
    }
}