using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IAuthService
    {
        UserModel GetUserForLogin(string contact, string pass);
        string GetToken(UserModel user);
        void ChangeUserPassword(int id, string newPassword, string oldPassword);
        void ChangeUserEmail(int id, string oldContact, string newContact, string token);
        void ConfirmNewEmail(int id, string contact);
        void ForgotPassword(string email);
        void ResetPassword(string password, string token);
    }
}