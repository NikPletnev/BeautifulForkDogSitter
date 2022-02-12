using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        List<Comment> GetAll();
        Comment GetById(int id);
        void Update(Comment comment);
        void Update(int id, bool IsDeleted);
    }
}