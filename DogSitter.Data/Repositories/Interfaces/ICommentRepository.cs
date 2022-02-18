using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        List<Comment> GetAll();
        List<Comment> GetAllComentsBySitterId(int id);
        Comment GetById(int id);
        void Update(Comment comment);
        void Update(Comment comment, bool IsDeleted);
    }
}