namespace DogSitter.API.Models
{
    public class AdminOutputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactOutputModel> Contacts { get; set; }

    }
}

