namespace DogSitter.BLL.Models
{
    public class AdminModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactModel> Contacts { get; set; }

        public override bool Equals(object obj)
        {
            if (Contacts.Count != ((AdminModel)obj).Contacts.Count)
            {
                return false;
            }

            for (int i = 0; i < Contacts.Count; i++)
            {
                if(Contacts[i] != ((AdminModel)obj).Contacts[i])
                {
                    return false;
                }
            }

            return obj is AdminModel model &&
                   Id == model.Id &&
                   Password == model.Password &&
                   FirstName == model.FirstName &&
                   LastName == model.LastName;                  
        }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Password}";
        }
    }
}
