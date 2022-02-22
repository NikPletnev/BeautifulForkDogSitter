using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface ICommentService
    {
        void DeleteById(int id);
        List<CommentModel> GetAll();
        List<CommentModel> GetAllCommentsBySitterId(int id);
    }
}