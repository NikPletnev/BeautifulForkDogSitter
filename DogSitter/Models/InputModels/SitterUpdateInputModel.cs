namespace DogSitter.API.Models
{
    public class SitterUpdateInputModel
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactInsertInputModel> Contacts { get; set; }
        public SubwayStationInputModel SubwayStation { get; set; }

    }
}
