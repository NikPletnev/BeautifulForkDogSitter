using DogSitter.DAL.Enums;

namespace DogSitter.BLL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactModel> Contacts { get; set; }
        public bool IsDeleted { get; set; }
        public Role Role { get; set; }

        public override bool Equals(object obj)
        {
            if (Contacts.Count != ((UserModel)obj).Contacts.Count)
            {
                return false;
            }

            for (int i = 0; i < Contacts.Count; i++)
            {
                if (!Equals(Contacts[i], ((UserModel)obj).Contacts[i]))
                {
                    return false;
                }
            }

            return obj is UserModel model &&
                   Id == model.Id &&
                   Password == model.Password &&
                   FirstName == model.FirstName &&
                   LastName == model.LastName;
        }
    }
}
