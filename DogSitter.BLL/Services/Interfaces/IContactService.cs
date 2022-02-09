using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IContactService
    {
        void AddContact(ContactModel contact);
        void DeleteContact(int id);
        List<ContactModel> GetAllContacts();
        ContactModel GetContactById(int id);
        void RestoreContact(int id);
        void UpdateContact(int id, ContactModel contactModel);
    }
}