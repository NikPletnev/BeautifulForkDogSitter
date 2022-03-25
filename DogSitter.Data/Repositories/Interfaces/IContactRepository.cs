using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAllContactsByCustomerId(int id);
        List<Contact> GetAllContactsBySitterId(int id);
        List<Contact> GetAllContacts();
        Contact GetContactByValue(string value);
        void UpdateContact(Contact contact, string value);
    }
}