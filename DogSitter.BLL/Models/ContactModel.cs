namespace DogSitter.BLL.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        public ContactTypeModel ContactType { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ContactModel model &&
                   Id == model.Id &&
                   Value == model.Value &&
                   IsDeleted == model.IsDeleted &&
                   ContactType.Name == model.ContactType.Name &&
                   ContactType.IsDeleted == model.ContactType.IsDeleted &&
                   ContactType.Id == model.ContactType.Id;
        }

        public override string ToString()
        {
            return $"{Id} {Value} {ContactType.Name}";
        }
    }
}
