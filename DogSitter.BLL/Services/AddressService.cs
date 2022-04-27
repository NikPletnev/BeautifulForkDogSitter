using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public AddressService(IMapper mapper, IAddressRepository addressRepository,
            ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _repository = addressRepository;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<AddressModel> GetAllAddresses()
        {
            var address = _repository.GetAllAddress();
            return _mapper.Map<List<AddressModel>>(address);
        }

        public void DeleteAddressById(int userId, int id)
        {
            var entity = _repository.GetAddressById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Address not found");
            }
            var user = _userRepository.GetUserById(userId);
            if (user.Role != Role.Admin && entity.Customer.Id != userId)
            {
                throw new AccessException("Not enough rights");
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

    }
}
