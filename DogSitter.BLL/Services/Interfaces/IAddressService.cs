using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IAddressService
    {
        void DeleteAddressById(int userId, int id);
        List<AddressModel> GetAllAddresses();
        void RestoreAddress(int id);
    }
}