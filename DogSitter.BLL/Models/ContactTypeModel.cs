namespace DogSitter.BLL.Models
{
    public class ContactTypeModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ContactTypeModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   IsDeleted == model.IsDeleted;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {IsDeleted}";
        }
    }
}
