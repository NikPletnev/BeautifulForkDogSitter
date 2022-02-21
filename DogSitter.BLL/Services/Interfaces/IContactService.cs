using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IContactService
    {
        void AddContact(ContactModel contact);
        void DeleteContact(int id);
        List<ContactModel> GetAllContacts();
        List<ContactModel> GetAllContactsByAdminId(int id);
        List<ContactModel> GetAllContactsByCustomerId(int id);
        List<ContactModel> GetAllContactsBySitterId(int id);
        ContactModel GetContactById(int id);
        void RestoreContact(int id);
        void UpdateContact(int id, ContactModel contactModel);
    }
}