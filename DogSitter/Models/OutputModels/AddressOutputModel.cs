namespace DogSitter.API.Models
{
    public class AddressOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public string Street { get; set; }
        public int House { get; set; }
        public int Apartament { get; set; }
        public List<SubwayStationOutputModel> SubwayStations { get; set; }
    }
}
