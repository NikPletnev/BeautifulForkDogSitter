using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface ICommentRepository
    {
        int Add(Comment comment);
        List<Comment> GetAll();
        List<Comment> GetAllComentsBySitterId(int id);
        Comment GetById(int id);
        void Update(Comment comment, Comment entity);
        void Update(Comment comment, bool IsDeleted);
    }
}