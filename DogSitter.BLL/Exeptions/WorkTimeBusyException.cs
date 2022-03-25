namespace DogSitter.BLL.Exeptions
{
    public class WorkTimeBusyException : Exception
    {
        public WorkTimeBusyException(string message) : base(message)
        {

        }

    }
}
