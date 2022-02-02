namespace DogSitter.API.Models
{
    public class DogInsertInputModel : DogUpdateOutputModel
    {
        //add
        public CustomerModel Customer { get; set; }

    }
}
