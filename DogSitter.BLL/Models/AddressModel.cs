namespace DogSitter.BLL.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int Apartament { get; set; }
        public bool IsDeleted { get; set; }
        public List<SubwayStationModel> SubwayStations { get; set; }

        public override bool Equals(object obj)
        {
            if (SubwayStations != null && ((AddressModel)obj).SubwayStations != null)
            {
                if (SubwayStations.Count != ((AddressModel)obj).SubwayStations.Count)
                {
                    return false;
                }

                for (int i = 0; i < SubwayStations.Count; i++)
                {
                    if (SubwayStations[i].Name != ((AddressModel)obj).SubwayStations[i].Name ||
                        SubwayStations[i].Id != ((AddressModel)obj).SubwayStations[i].Id)
                    {
                        return false;
                    }
                }

            }

            return obj is AddressModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   City == model.City &&
                   Street == model.Street &&
                   House == model.House &&
                   Apartament == model.Apartament &&
                   IsDeleted == model.IsDeleted;
        }


    }
}