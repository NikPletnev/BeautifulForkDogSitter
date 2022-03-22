using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace DogSitter.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _map;
        private readonly ILogger<EmailSendller> _logger;

        public AuthService(IContactRepository contactRepository, IUserRepository userRepository, IMapper mapper, ILogger<EmailSendller> logger)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
            _map = mapper;
            _logger = logger;
        }

        public void ConfirmNewEmail(int id, string contact)
        {
            var user = _userRepository.GetUserById(id);
            var resetToken = randomTokenString();
            var resetTokenExpires = DateTime.Now.AddMinutes(5);
            _userRepository.AddTokenForResetPasswordAndEditEmail(user, resetToken, resetTokenExpires);
            EmailSendller emailSendller = new EmailSendller(_logger);
            emailSendller.SendEmailCustom(contact, EmailMessage.ConfirmNewEmail(resetToken), EmailTopic.ConfirmNewEmail);
        }

        public void ChangeUserEmail(int id, string oldContact, string newContact, string token)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null || user.ResetTokenExpires < DateTime.Now || user.ResetToken != token)
            {
                throw new Exception("Invalid token");
            }

            var contact = _contactRepository.GetContactByValue(oldContact);
            _contactRepository.UpdateContact(contact, newContact);

            EmailSendller emailSendller = new EmailSendller(_logger);
            emailSendller.SendEmailCustom(newContact, EmailMessage.ChangeUserEmailForNewEmail, EmailTopic.EmailChange);
            emailSendller.SendEmailCustom(oldContact, EmailMessage.ChangeUserEmailForOldEmail, EmailTopic.EmailChange);

        }

        public void ForgotPassword(string email)
        {
            var foundContact = _contactRepository.GetContactByValue(email);
            if (foundContact == null || foundContact.User == null || foundContact.User.IsDeleted)
            {
                throw new EntityNotFoundException("Invalid username or password entered");
            }
            var resetToken = randomTokenString();
            var resetTokenExpires = DateTime.Now.AddMinutes(5);
            _userRepository.AddTokenForResetPasswordAndEditEmail(foundContact.User, resetToken, resetTokenExpires);
            EmailSendller emailSendller = new EmailSendller(_logger);
            emailSendller.SendMessage(_map.Map<UserModel>(foundContact.User), EmailMessage.RestorePessword(resetToken), EmailTopic.ResetPassword);
        }

        public void ResetPassword(string password, string token)
        {
            var user = _userRepository.GetUserByResetToken(token);
            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                throw new Exception("Invalid token");
            }
            string hashPassword = PasswordHash.HashPassword(password);
            _userRepository.ResetPassword(hashPassword, user);

            EmailSendller emailSendller = new EmailSendller(_logger);
            emailSendller.SendMessage(_map.Map<UserModel>(user), EmailMessage.PasswordChange, EmailTopic.PasswordChange);
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

            EmailSendller emailSendller = new EmailSendller(_logger);
            emailSendller.SendMessage(_map.Map<UserModel>(user), EmailMessage.PasswordChange, EmailTopic.PasswordChange);
        }

        private string randomTokenString()
        {

            var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}
