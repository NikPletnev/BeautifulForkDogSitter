
namespace DogSitter.API.Models
{
    public class AddressInputModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Apartament { get; set; }
        public virtual List<SubwayStationInputModel> SubwayStations { get; set; }
    }
}
