
using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _rep;
        private readonly IMapper _mapper;
        private readonly IAdminRepository _adminRepository;
        private readonly ISitterRepository _sitterRepository;
        private readonly ICustomerRepository _customerRepository;

        public ContactService(IContactRepository contactRepository, IMapper mapper, ICustomerRepository customerRepository,
            IAdminRepository adminRepository, ISitterRepository sitterRepository)
        {
            _rep = contactRepository;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _sitterRepository = sitterRepository;
            _adminRepository = adminRepository;
        }

        public List<ContactModel> GetAllContacts()
        {
            return _mapper.Map<List<ContactModel>>(_rep.GetAllContacts());
        }

        public List<ContactModel> GetAllContactsByCustomerId(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                throw new EntityNotFoundException($"Customer {id} not found");
            }
            return _mapper.Map<List<ContactModel>>(_rep.GetAllContactsByCustomerId(id));
        }

        public List<ContactModel> GetAllContactsBySitterId(int id)
        {
            var sitter = _sitterRepository.GetById(id);
            if (sitter == null)
            {
                throw new EntityNotFoundException($"Sitter {id} not found");
            }
            return _mapper.Map<List<ContactModel>>(_rep.GetAllContactsBySitterId(id));
        }

    }
}
