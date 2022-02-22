namespace DogSitter.BLL.Exeptions
{
    public class AccessException : Exception
    {
        public AccessException(string message) : base(message) { }
    }
}
