
using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _rep;
        private IMapper _mapper;
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

        public void UpdateContact(int id, ContactModel contactModel)
        {
            if (contactModel.ContactType == null ||
                contactModel.Value == String.Empty)
            { 
                throw new ServiceNotEnoughDataExeption($"There is not enough data to edit the contact {id}");
            }

            var contact = _mapper.Map<Contact>(contactModel);
            var entity = _rep.GetContactById(id);

            if (entity == null)
            {
                throw new EntityNotFoundException($"Contact {id} was not found");
            }

            _rep.UpdateContact(entity, contact);
        }

        public void DeleteContact(int id)
        {
            var contact = _rep.GetContactById(id);

            if (contact == null)
            {
                throw new EntityNotFoundException($"Contact {id} was not found");
            }

            _rep.UpdateContact(contact, true);
        }

        public void RestoreContact(int id)
        {
            var contact = _rep.GetContactById(id);

            if (contact == null)
            {
                throw new EntityNotFoundException($"Contact {id} was not found");
            }

            _rep.UpdateContact(contact, false);
        }

        public void AddContact(ContactModel contact)
        {
            if (contact.ContactType == null ||
               contact.Value == String.Empty)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to add new contact");
            }

            _rep.AddContact(_mapper.Map<Contact>(contact));
        }

        public ContactModel GetContactById(int id)
        {
            var contact = _rep.GetContactById(id);
            if (contact == null)
            {
                throw new EntityNotFoundException($"Contact {id} was not found");
            }

            return _mapper.Map<ContactModel>(contact);
        }

        public List<ContactModel> GetAllContacts()
        {
            return _mapper.Map<List<ContactModel>>(_rep.GetAllContacts());
        }

        public List<ContactModel> GetAllContactsByAdminId(int id)
        {
            var admin =  _adminRepository.GetAdminById(id);
            if(admin == null)
            {
                throw new EntityNotFoundException($"Admin {id} not found");
            }
            return _mapper.Map<List<ContactModel>>(_rep.GetAllContactsByAdminId(id));
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
