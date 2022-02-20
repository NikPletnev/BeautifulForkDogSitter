using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface ICommentService
    {
        void Add(CommentModel commentModel);
        void DeleteById(int id);
        List<CommentModel> GetAll();
        List<CommentModel> GetAllCommentsBySitterId(int id);
        CommentModel GetById(int id);
        void Restore(int id);
        void Update(CommentModel commentModel);
    }
}