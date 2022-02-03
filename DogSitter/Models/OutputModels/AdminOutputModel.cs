namespace DogSitter.API.Models
{
    public class AdminOutputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactUpdateInputModel> Contacts { get; set; }

    }
}

