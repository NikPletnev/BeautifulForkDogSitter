using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        void ChangeUserPassword(string password, User user);
        void AddTokenForResetPasswordAndEditEmail(User user, string token, DateTime date);
        User GetUserByResetToken(string token);
        void ResetPassword(string password, User user);
    }
}