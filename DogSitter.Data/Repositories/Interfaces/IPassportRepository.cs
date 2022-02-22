using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IPassportRepository
    {
        void AddPassport(Passport passport);
        Passport GetPassportById(int id);
        void UpdatePassport(Passport entity, Passport passport);
    }
}