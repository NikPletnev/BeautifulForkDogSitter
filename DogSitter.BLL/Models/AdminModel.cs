namespace DogSitter.BLL.Models
{
    public class AdminModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactModel> Contacts { get; set; }
    }
}
