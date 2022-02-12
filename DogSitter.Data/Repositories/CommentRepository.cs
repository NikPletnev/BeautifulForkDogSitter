using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private DogSitterContext _context;

        public CommentRepository()
        {
            _context = DogSitterContext.GetInstance();
        }

        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public Comment GetById(int id) =>
             _context.Comments.FirstOrDefault(x => x.Id == id);

        public List<Comment> GetAll() =>
            _context.Comments.Where(d => !d.IsDeleted).ToList();

        public void Update(Comment comment)
        {
            var entity = GetById(comment.Id);
            entity.Text = comment.Text;
            entity.Date = comment.Date;
            _context.SaveChanges();
        }

        public void Update(int id, bool IsDeleted)
        {
            Comment comment = GetById(id);
            comment.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}
