using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class WorkTimeRepository : IWorkTimeRepository
    {
        private readonly DogSitterContext _context;

        public WorkTimeRepository(DogSitterContext context)
        {
            _context = context;
        }

        public WorkTime GetWorkTimeById(int id) =>
                     _context.WorkTimes.FirstOrDefault(w => w.Id == id);

        public int AddWorkTime(WorkTime workTime)
        {
            _context.WorkTimes.Add(workTime);
            _context.SaveChanges();

            return workTime.Id;
        }

        public void UpdateWorkTime(WorkTime exitingWorkTime, WorkTime worktimeToUpdate)
        {
            exitingWorkTime.Start = worktimeToUpdate.Start;
            exitingWorkTime.End = worktimeToUpdate.End;
            exitingWorkTime.Weekday = worktimeToUpdate.Weekday;
            _context.SaveChanges();
        }

        public void UpdateOrDeleteWorkTime(WorkTime workTime, bool IsDeleted)
        {
            workTime.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}
