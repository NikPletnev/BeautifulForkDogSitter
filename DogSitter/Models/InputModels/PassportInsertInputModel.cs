namespace DogSitter.API.Models
{
    public class PassportInsertInputModel : PassportUpdateOutputModel
    {        
        public int SitterId { get; set; }
    }
}
