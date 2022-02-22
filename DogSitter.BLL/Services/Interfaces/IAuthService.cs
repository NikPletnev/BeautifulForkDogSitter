using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IAuthService
    {
        UserModel GetUserForLogin(string contact, string pass);
        string GetToken(UserModel user);
    }
}