using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IAddressService
    {
        void AddAddress(AddressModel address);
        void DeleteAddressById( int id);
        AddressModel GetAddressByCustomerId(int id);
        AddressModel GetAddressById(int id);
        List<AddressModel> GetAllAddresses();
        void RestoreAddress(int id);
        void UpdateAddress(AddressModel address);
    }
}