using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class WorkTimeRepository
    {
        private readonly DogSitterContext _context;

        public WorkTimeRepository()
        {
            _context = DogSitterContext.GetInstance();
        }

        public WorkTime GetWorkTimeById(int id) =>
                     _context.WorkTimes.FirstOrDefault(w => w.Id == id);

        public void AddWorkTime(WorkTime workTime)
        {
            _context.WorkTimes.Add(workTime);
            _context.SaveChanges();
        }

        public void DeleteWorkTime(int id)
        {
            var workTime = GetWorkTimeById(id);
            _context.WorkTimes.Remove(workTime);
            _context.SaveChanges();
        }

        public void UpdateWorkTime(WorkTime workTime)
        {
            var trackingWorkTime = _context.ChangeTracker.Entries<WorkTime>()
                .First(a => a.Entity.Id == workTime.Id).Entity;

            trackingWorkTime.Start = workTime.Start;
            trackingWorkTime.End = workTime.End;
            trackingWorkTime.Weekday = workTime.Weekday;
            _context.SaveChanges();
        }

        public void UpdateWorkTime(int id, bool IsDeleted)
        {
            var entity = GetWorkTimeById(id);
            entity.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
        public void RestoreWorkTime(WorkTime workTime, bool IsDeleted)
        {
            workTime.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }

    }
}
