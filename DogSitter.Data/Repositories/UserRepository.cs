using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DogSitterContext _context;

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
    }
}
