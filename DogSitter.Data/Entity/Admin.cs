namespace DogSitter.DAL.Entity
{
    public class Admin : User
    {

        public override bool Equals(object obj)
        {

            return obj is Admin admin &&
                   Id == admin.Id &&
                   Password == admin.Password &&
                   FirstName == admin.FirstName &&
                   LastName == admin.LastName &&
                   IsDeleted == admin.IsDeleted;
        }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Password}";
        }

    }
}
