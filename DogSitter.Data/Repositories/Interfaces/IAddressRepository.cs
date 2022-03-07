using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IAddressRepository
    {
        int AddAddress(Address address);
        Address GetAddressById(int id);
        List<Address> GetAllAddress();
        void UpdateAddress(Address address);
        void UpdateAddress(int id, bool IsDeleted);
        Address GetAddressByCustomerId(Customer customer);
    }
}