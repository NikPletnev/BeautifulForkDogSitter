namespace DogSitter.BLL.Services
{
    public interface IEmailSendllerService
    {
        void SendEmailCustom();
        void SendEmailDefault();
    }
}