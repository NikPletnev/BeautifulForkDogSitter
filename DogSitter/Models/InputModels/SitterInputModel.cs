namespace DogSitter.API.Models.InputModels
{
    public class SitterInputModel //добавление
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<ContactUpdateInputModel> Contacts { get; set; }
        public AddressInputModel Address { get; set; }
        public List<ServiceInputModel> Services { get; set; }
        public List<WorkTimeInsertInputModel> WorkTimes { get; set; }
        public List<OrderInsertInputModel> Orders { get; set;  }

    }
}