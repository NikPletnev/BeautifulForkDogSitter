using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DogSitter.BLL.Configs
{
    public class AuthOptions
    {
        public const string Issuer = "DogSitterBack"; // издатель токена
        public const string Audience = "DogSitterFront"; // потребитель токена
        private const string _key = "mysupersecret_secretkey!123";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
    }
}
