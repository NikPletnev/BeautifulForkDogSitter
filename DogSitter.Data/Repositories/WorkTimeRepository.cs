using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class WorkTimeRepository
    {
        private readonly DogSitterContext _context;

        public WorkTimeRepository(DogSitterContext context)
        {
            _context = context;
        }

        public List<WorkTime> GetAllWorkTimes() =>
            _context.WorkTimes.Where(w => !w.IsDeleted).ToList();

        public WorkTime GetWorkTimeById(int id) =>
            _context.WorkTimes.FirstOrDefault(w => w.Id == id);

        public void AddWorkTime(WorkTime workTime)
        {
            _context.WorkTimes.Add(workTime);
            _context.SaveChanges();
        }

        public void UpdateWorkTime(WorkTime workTime)
        {
            entity.Start = workTime.Start;
            entity.End = workTime.End;
            entity.Weekdays = workTime.Weekdays;
            _context.SaveChanges();
        }

        public void UpdateWorkTime(WorkTime workTime, bool IsDeleted)
        {
            workTime.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}
