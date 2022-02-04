namespace DogSitter.API.Models
{
    public class PassportInsertInputModel : PassportUpdateInputModel
    {
        public SitterOutputModel Sitter { get; set; }
    }
}
