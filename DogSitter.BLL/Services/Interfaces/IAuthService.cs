using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IAuthService
    {
        string LoginAdmin(string contact, string pass);
        string LoginCustomer(string contact, string pass);
        string LoginSitter(string contact, string pass);
    }
}