using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IAdminRepository
    {
        void AddAdmin(Admin admin);
        Admin GetAdminById(int id);
        List<Admin> GetAllAdmins();
        Admin Login(Contact contact, string pass);
        void UpdateAdmin(Admin admin);
        void UpdateAdmin(int id, bool isDeleted);
        List<Admin> GetAllAdminWithContacts();
        Admin GetAdminByIdWithContacts(int id);
    }
}