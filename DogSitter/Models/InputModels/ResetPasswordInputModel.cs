namespace DogSitter.API.Models
{
    public class ResetPasswordInputModel
    {
        public string NewPassword { get; set; }
        public string Token { get; set; }
    }
}
