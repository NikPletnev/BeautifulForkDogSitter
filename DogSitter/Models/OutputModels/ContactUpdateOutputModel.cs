namespace DogSitter.API.Models
{
    public class ContactOutputModel
    {
        public string Value { get; set; }
        public ContactTypeUpdateOutputModel contactType { get; set; }

    }
}
