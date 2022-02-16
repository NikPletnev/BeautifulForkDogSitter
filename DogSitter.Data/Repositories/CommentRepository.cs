using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private DogSitterContext _context;

        public CommentRepository(DogSitterContext context)
        {
            _context = context;
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
            var entity = _context.ChangeTracker.Entries<Comment>()
                .First(a => a.Entity.Id == comment.Id).Entity;

            entity.Text = comment.Text;
            entity.Date = comment.Date;
            _context.SaveChanges();
        }

        public void Update(Comment comment, bool IsDeleted)
        {
            comment.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}
