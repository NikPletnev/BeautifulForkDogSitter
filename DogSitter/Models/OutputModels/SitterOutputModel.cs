namespace DogSitter.API.Models
{
    public class SitterOutputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactInsertInputModel> Contacts { get; set; }
        public SubwayStationInputModel SubwayStation { get; set; }
        public string Information { get; set; }
    }
}