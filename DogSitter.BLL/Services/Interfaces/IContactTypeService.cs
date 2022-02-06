using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IContactTypeService
    {
        void AddContactType(ContactTypeModel contactType);
        void DeleteContactType(int id);
        List<ContactTypeModel> GetAllContactTypes();
        ContactTypeModel GetContactTypeById(int id);
        void RestoreContactType(int id);
        void UpdateContactType(int id, ContactTypeModel contactTypeModel);
    }
}