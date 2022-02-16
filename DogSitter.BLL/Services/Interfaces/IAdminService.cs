using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IAdminService
    {
        void AddAdmin(AdminModel adminModel);
        void DeleteAdmin(int id);
        AdminModel GetAdminById(int id);
        AdminModel GetAdminWithContacts(int id);
        List<AdminModel> GetAllAdmins();
        List<AdminModel> GetAllAdminsWithContacts();
        void RestoreAdmin(int id);
        void UpdateAdmin(int id, AdminModel adminModel);
    }
}