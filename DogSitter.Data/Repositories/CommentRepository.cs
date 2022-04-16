using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DogSitterContext _context;

        public CommentRepository(DogSitterContext context)
        {
            _context = context;
        }

        public int Add(Comment comment)
        {
            var entity = _context.Comments.Add(comment);
            _context.SaveChanges();
            return entity.Entity.Id;
        }

        public Comment GetById(int id) =>
             _context.Comments.FirstOrDefault(x => x.Id == id);

        public List<Comment> GetAll() =>
            _context.Comments.Where(d => !d.IsDeleted).ToList();

        public void Update(Comment comment, Comment entity)
        {
            comment.Text = entity.Text;
            comment.Date = entity.Date;
            _context.SaveChanges();
        }

        public void Update(Comment comment, bool IsDeleted)
        {
            comment.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }

        public List<Comment> GetAllComentsBySitterId(int id) =>
            _context.Comments.Where(x => x.Order.Sitter.Id == id).Include(x => x.Customer).ToList();

    }
}
