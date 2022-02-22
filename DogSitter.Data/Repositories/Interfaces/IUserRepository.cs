using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
    }
}