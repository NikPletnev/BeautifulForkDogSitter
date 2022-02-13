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

        public string LoginAdmin(string contact, string pass)
        {

            Contact findedContact = _contactRepository.GetContactByValue(contact);
            AdminModel admin;
            if (findedContact != null)
            {
                var findedAdmin = _adminRepository.Login(findedContact, pass);
                if (findedAdmin == null)
                {
                    throw new ServiceNotFoundExeption("Admin not found");
                }
                else
                {
                    admin = _map.Map<AdminModel>(findedAdmin);
                }
            }
            else
            {
                throw new ServiceNotFoundExeption("Contact not found");
            }
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, admin.FirstName ),
                new Claim(ClaimTypes.UserData, admin.Id.ToString())
            };

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }

        public string LoginCustomer(string contact, string pass)
        {
            Contact findedContact = _contactRepository.GetContactByValue(contact);
            CustomerModel customer;
            if (findedContact != null)
            {
                var findedCustomer = _customerRepository.Login(findedContact, pass);
                if (findedCustomer == null)
                {
                    throw new ServiceNotFoundExeption("Customer not found");
                }
                else
                {
                    customer = _map.Map<CustomerModel>(findedCustomer);
                }
            }
            else
            {
                throw new ServiceNotFoundExeption("Contact not found");
            }
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, customer.FirstName ),
                new Claim(ClaimTypes.UserData, customer.Id.ToString())
            };

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string LoginSitter(string contact, string pass)
        {
            Contact findedContact = _contactRepository.GetContactByValue(contact);
            SitterModel sitter;
            if (findedContact != null)
            {
                var findedSitter = _sitterRepository.Login(findedContact, pass);
                if (findedSitter == null)
                {
                    throw new ServiceNotFoundExeption("Sitter not found");
                }
                else
                {
                    sitter = _map.Map<SitterModel>(findedSitter);
                }
            }
            else
            {
                throw new ServiceNotFoundExeption("Contact not found");
            }
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, sitter.FirstName ),
                new Claim(ClaimTypes.UserData, sitter.Id.ToString())
            };

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

    }
}
