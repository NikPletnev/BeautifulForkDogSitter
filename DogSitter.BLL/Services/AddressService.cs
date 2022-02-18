using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _repository;
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public AddressService(IMapper mapper, IAddressRepository addressRepository, ICustomerRepository customerRepository)
        {
            _repository = addressRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public AddressModel GetAddressById(int id)
        {
            var address = _repository.GetAddressById(id);
            if (address == null)
            {
                throw new EntityNotFoundException("Address not found");

            }
            return _mapper.Map<AddressModel>(address);
        }

        public List<AddressModel> GetAllAddresses()
        {
            var address = _repository.GetAllAddress();
            return _mapper.Map<List<AddressModel>>(address);
        }

        public void AddAddress(AddressModel address)
        {
            if (address.Name == String.Empty ||
               address.City == String.Empty ||
               address.Street == String.Empty ||
               address.House == 0 ||
               address.Apartament == 0)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to create new address");
            }
            var addressModel = _mapper.Map<Address>(address);
            _repository.AddAddress(addressModel);
        }

        public void UpdateAddress(AddressModel address)
        {
            if (address.Name == String.Empty ||
              address.City == String.Empty ||
              address.Street == String.Empty ||
              address.House == 0 ||
              address.Apartament == 0)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to update address");
            }
            var addressModel = _mapper.Map<Address>(address);
            var entity = _repository.GetAddressById(address.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Address not found");

            }
            _repository.UpdateAddress(addressModel);
        }

        public void DeleteAddressById(int id)
        {
            var entity = _repository.GetAddressById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Address not found");
            }
            _repository.UpdateAddress(id, true);
        }

        public void RestoreAddress(int id)
        {
            var entity = _repository.GetAddressById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Address not found");
            }
            _repository.UpdateAddress(id, false);
        }

        public AddressModel GetAddressByCustomerId(int id)
        {
            var entity = _customerRepository.GetCustomerById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Customer {id} was not found");
            }
            return _mapper.Map<AddressModel>(_repository.GetAddressByCustomerId(entity));
        }

    }
}
