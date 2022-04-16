using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DogSitterContext _context;

        public AddressRepository(DogSitterContext context)
        {
            _context = context;
        }

        public Address GetAddressById(int id) =>
             _context.Addresses.FirstOrDefault(x => x.Id == id);

        public List<Address> GetAllAddress() =>
            _context.Addresses.Where(d => !d.IsDeleted).ToList();

        public int AddAddress(Address address)
        {
            var entity = _context.Addresses.Add(address);
            _context.SaveChanges();
            return entity.Entity.Id;
        }

        public void UpdateAddress(Address address)
        {
            var entity = GetAddressById(address.Id);
            entity.Name = address.Name;
            entity.City = address.City;
            entity.Street = address.Street;
            entity.House = address.House;
            entity.Apartament = address.Apartament;
            entity.SubwayStations = address.SubwayStations;
            _context.SaveChanges();
        }

        public void UpdateAddress(int id, bool IsDeleted)
        {
            Address address = GetAddressById(id);
            address.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }

        public Address GetAddressByCustomerId(Customer customer)
            => customer.Address;

    }
}