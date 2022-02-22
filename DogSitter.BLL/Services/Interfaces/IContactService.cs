using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IContactService
    {
        List<ContactModel> GetAllContacts();
        List<ContactModel> GetAllContactsByCustomerId(int id);
        List<ContactModel> GetAllContactsBySitterId(int id);
        ContactModel GetContactById(int id);
        void RestoreContact(int id);
        void UpdateContact(int id, ContactModel contactModel);
    }
}