using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
