namespace DogSitter.API.Models
{
    public class DogInsertInputModel : DogUpdateInputModel
    {
        //создание
        public CustomerOutputModel Customer { get; set; }

    }
}
