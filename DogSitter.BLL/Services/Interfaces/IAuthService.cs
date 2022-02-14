using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IAuthService
    {
        AdminModel GetAdminForLogin(string contact, string pass);
        CustomerModel GetCustomerForLogin(string contact, string pass);
        SitterModel GetSitterForLogin(string contact, string pass);
        string LoginUser(UserModel user);
    }
}