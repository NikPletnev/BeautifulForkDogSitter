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

        public int AddWorkTime(WorkTime workTime, Sitter sitter)
        {
            workTime.Sitter = sitter;
            if(sitter.WorkTime == null)
            {
                sitter.WorkTime = new List<WorkTime>();
            }
            sitter.WorkTime.Add(workTime);
            var workTimeId = _context.WorkTimes.Add(workTime);
            _context.SaveChanges();
            return workTimeId.Entity.Id;
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

        public List<WorkTime> GetWorkTimeBySitterId(int id)
        {
            var result = _context.WorkTimes.Where(w => w.Sitter.Id == id).ToList();
            return result;
        }
        
        public void ChangeWorkTimeStatus(WorkTime workTime, bool isBusy)
        {
            workTime.IsBusy = isBusy;
            _context.SaveChanges();
        }
    }
}
