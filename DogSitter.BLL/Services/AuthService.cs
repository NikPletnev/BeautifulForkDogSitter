using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DogSitter.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _map;

        public AuthService(IContactRepository contactRepository, IUserRepository userRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
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
                throw new EntityNotFoundException("Invalid username or password entered");
            }
            if (foundContact.User.IsDeleted)
            {
                throw new EntityNotFoundException("User not found or deleted");
            }

            UserModel user = _map.Map<UserModel>(foundContact.User);
            return user;
        }

        public void ChangeUserPassword(int id, string newPassword, string oldPassword)
        {
            var user = _userRepository.GetUserById(id);

            if (user is null)
            {
                throw new EntityNotFoundException("User wasn't found");
            }

            if (!PasswordHash.ValidatePassword(oldPassword, user.Password))
            {
                throw new PasswordException("Passwords don't match");
            }

            string hashPassword = PasswordHash.HashPassword(newPassword);
            _userRepository.ChangeUserPassword(hashPassword, user);
        }
    }
}
