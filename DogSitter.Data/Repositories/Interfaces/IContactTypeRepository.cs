using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IContactTypeRepository
    {
        void AddContactType(ContactType contactType);
        List<ContactType> GetAllContactTypes();
        ContactType GetContactTypeById(int id);
        void UpdateContactType(ContactType contactType);
        void UpdateContactType(int id, bool isDeleted);
    }
}