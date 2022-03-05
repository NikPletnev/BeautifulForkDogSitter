using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IContactService
    {
        List<ContactModel> GetAllContacts();
        List<ContactModel> GetAllContactsByCustomerId(int id);
        List<ContactModel> GetAllContactsBySitterId(int id);
    }
}