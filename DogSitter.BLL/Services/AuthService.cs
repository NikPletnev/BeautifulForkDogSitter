using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DogSitter.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISitterRepository _sitterRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _map;

        public AuthService(IContactRepository contactRepository ,IAdminRepository adminRepository,
            ICustomerRepository customerRepository, ISitterRepository sitterRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _customerRepository = customerRepository;
            _sitterRepository = sitterRepository;
            _contactRepository = contactRepository;
            _map = mapper;
        }

        public string GetToken(UserModel user)
        {            
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.FirstName ),
                new Claim(ClaimTypes.UserData, user.Id.ToString())
            };

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public AdminModel GetAdminForLogin(string contact, string pass)
        {
            Contact foundContact = _contactRepository.GetContactByValue(contact);
            AdminModel admin;
            if (foundContact != null)
            {
                var foundAdmin = _adminRepository.Login(foundContact, pass);
                if (foundAdmin == null)
                {
                    throw new EntityNotFoundException("Admin not found");
                }
                else
                {
                    admin = _map.Map<AdminModel>(foundAdmin);
                }
            }
            else
            {
                throw new EntityNotFoundException("Contact not found");
            }
            return admin;
        }

        public CustomerModel GetCustomerForLogin(string contact, string pass)
        {
            Contact foundContact = _contactRepository.GetContactByValue(contact);
            CustomerModel customer;
            if (foundContact != null)
            {
                var foundCustomer = _customerRepository.Login(foundContact, pass);
                if (foundCustomer == null)
                {
                    throw new EntityNotFoundException("Customer not found");
                }
                else
                {
                    customer = _map.Map<CustomerModel>(foundCustomer);
                }
            }
            else
            {
                throw new EntityNotFoundException("Contact not found");
            }
            return customer;
        }

        public SitterModel GetSitterForLogin(string contact, string pass)
        {
            Contact foundContact = _contactRepository.GetContactByValue(contact);
            SitterModel sitter;
            if (foundContact != null)
            {
                var foundSitter = _sitterRepository.Login(foundContact, pass);
                if (foundSitter == null)
                {
                    throw new EntityNotFoundException("Sitter not found");
                }
                else
                {
                    sitter = _map.Map<SitterModel>(foundSitter);
                }
            }
            else
            {
                throw new EntityNotFoundException("Contact not found");
            }
            return sitter;
        }

    }
}
