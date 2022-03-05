namespace DogSitter.BLL.Models
{
    public class CustomerModel : UserModel
    {
        public List<DogModel> Dogs { get; set; }
        public List<SitterModel> Sitter { get; set; }
        public int AddressId { get; set; }
        public AddressModel Address { get; set; }
        public List<OrderModel> Orders { get; set; }
        public List<CommentModel> Comments { get; set; }
        public override bool Equals(object obj)
        {
            if (Contacts != null && ((CustomerModel)obj).Contacts != null)
            {
                if (Contacts.Count != ((CustomerModel)obj).Contacts.Count)
                {
                    return false;
                }

                for (int i = 0; i < Contacts.Count; i++)
                {
                    if (Contacts[i].IsDeleted != ((CustomerModel)obj).Contacts[i].IsDeleted ||
                        Contacts[i].Value != ((CustomerModel)obj).Contacts[i].Value ||
                        Contacts[i].ContactType != ((CustomerModel)obj).Contacts[i].ContactType ||
                        Contacts[i].Id != ((CustomerModel)obj).Contacts[i].Id)
                    {
                        return false;
                    }
                }

            }
            return obj is CustomerModel model &&
                   base.Equals(obj) &&
                   Id == model.Id &&
                   Password == model.Password &&
                   FirstName == model.FirstName &&
                   LastName == model.LastName &&
                   IsDeleted == model.IsDeleted &&
                   Role == model.Role;
        }
    }
}
