namespace DogSitter.BLL.Models
{
    public class DogModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public string Breed { get; set; }
        public bool IsDeleted { get; set; }
        public CustomerModel Customer { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DogModel model &&
                   Name == model.Name &&
                   Age == model.Age &&
                   Weight == model.Weight &&
                   Description == model.Description &&
                   Breed == model.Breed &&
                   IsDeleted == model.IsDeleted;
        }
    }
}
