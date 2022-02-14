namespace DogSitter.BLL.Models
{
    public class AdminModel: UserModel
    {


        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Password}";
        }
    }
}
