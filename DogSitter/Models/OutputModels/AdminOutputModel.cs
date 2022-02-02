namespace DogSitter.API.Models
{
    public class AdminOutputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactUpdateOutputModel> Contacts { get; set; }

    }
}

