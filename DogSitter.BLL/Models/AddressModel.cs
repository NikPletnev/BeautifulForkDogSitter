namespace DogSitter.BLL.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Apartament { get; set; }
        public bool IsDeleted { get; set; }
        public  List<SubwayStationModel> SubwayStations { get; set; }

    }
}