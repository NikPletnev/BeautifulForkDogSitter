using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IPassportRepository
    {
        Passport GetPassportById(int id);
        void UpdatePassport(Passport entity, Passport passport);
    }
}