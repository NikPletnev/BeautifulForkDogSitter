using DogSitter.DAL.Entity;

namespace DogSitter.API.Models
{
    public class WorkTimeOutputModel : WorkTimeShortOutputModel
    {
        public List<Sitter> Sitters { get; set; }
    }
}
