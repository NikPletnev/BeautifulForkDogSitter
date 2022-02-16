namespace DogSitter.BLL.Models
{
    public class SubwayStationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SitterModel> Sitters { get; set; }
    }
}
