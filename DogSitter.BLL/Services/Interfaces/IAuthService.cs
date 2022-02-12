using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IAuthService
    {
        string LoginAdmin(string contact, string pass);
        CustomerModel LoginCustomer(string contact, string pass);
        CustomerModel LoginSitter(string contact, string pass);
    }
}