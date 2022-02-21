using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Helpers;
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
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _map;

        public AuthService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _map = mapper;
        }

        public string GetToken(UserModel user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.FirstName ),
                new (ClaimTypes.Role, user.Role.ToString()),
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

        public UserModel GetUserForLogin(string contact, string pass)
        {
            Contact foundContact = _contactRepository.GetContactByValue(contact);
            if (foundContact == null || foundContact.User == null || 
                !PasswordHash.ValidatePassword(pass, foundContact.User.Password))
            {
                throw new EntityNotFoundException("данные");
            }
            UserModel user = _map.Map<UserModel>(foundContact.User);
            return user;
        }
    }
}
