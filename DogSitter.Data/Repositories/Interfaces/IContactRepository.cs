using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        Contact GetContactByValue(string value);
        void UpdateContact(Contact contact);
        void UpdateContact(int id, bool isDeleted);
    }
}