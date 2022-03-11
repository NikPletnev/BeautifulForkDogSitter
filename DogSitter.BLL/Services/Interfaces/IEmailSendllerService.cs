namespace DogSitter.BLL.Helpers
{
    public interface IEmailSendllerService
    {
        void SendEmailCustom();
        void SendEmailDefault();
    }
}