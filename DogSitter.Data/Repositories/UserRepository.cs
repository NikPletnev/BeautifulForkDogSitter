using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DogSitterContext _context;

        public UserRepository(DogSitterContext context)
        {
            _context = context;
        }

        public User GetUserById(int id) =>
             _context.Users.FirstOrDefault(x => x.Id == id);

        public void ChangeUserPassword(string password, User user)
        {
            user.Password = password;
            _context.SaveChanges();
        }

        public void ResetPassword(string password, User user)
        {
            user.Password = password;
            user.ResetTokenExpires = null;
            user.ResetToken = null;
            _context.SaveChanges();
        }

        public User GetUserByResetToken(string token) =>
            _context.Users.Include(x => x.Contacts).FirstOrDefault(x => x.ResetToken == token);


        public void AddTokenForResetPasswordAndEditEmail(User user, string token, DateTime date)
        {
            user.ResetToken = token;
            user.ResetTokenExpires = date;
            _context.SaveChanges();
        }
    }
}
