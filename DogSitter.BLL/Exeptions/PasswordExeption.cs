namespace DogSitter.BLL.Exeptions
{
    public class PasswordException : Exception
    {
        public PasswordException(string message) : base(message) { }
    }
}
