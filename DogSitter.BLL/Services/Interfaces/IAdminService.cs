using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IAdminService
    {
        List<AdminModel> GetAllAdminsWithContacts();
        void UpdateAdmin(int id, AdminModel adminModel);
    }
}