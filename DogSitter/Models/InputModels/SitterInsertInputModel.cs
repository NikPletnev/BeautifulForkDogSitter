namespace DogSitter.API.Models.InputModels
{
    public class SitterInsertInputModel
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactInsertInputModel> Contacts { get; set; }
        public PassportInsertInputModel Passport { get; set; }
        public SubwayStationInputModel SubwayStation { get; set; }
        public string Information { get; set; }

    }
}
