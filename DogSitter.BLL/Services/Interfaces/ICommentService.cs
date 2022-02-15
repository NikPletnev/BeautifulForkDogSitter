using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface ICommentService
    {
        void Add(CommentModel commentModel);
        void DeleteById(CommentModel commentModel);
        List<CommentModel> GetAll();
        CommentModel GetById(int id);
        void Restore(int id);
        void Update(CommentModel commentModel);
    }
}