using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly DogSitterContext _context;

        public TimesheetRepository(DogSitterContext context)
        {
            _context = context;
        }

        public Timesheet GetTimesheetById(int id) =>
                     _context.Timesheets.FirstOrDefault(w => w.Id == id);

        public int AddTimesheet(Timesheet timesheet, Sitter sitter)
        {
            timesheet.Sitter = sitter;

            if (sitter.Timesheets == null)
            {
                sitter.Timesheets = new List<Timesheet>();
            }

            sitter.Timesheets.Add(timesheet);
            var timesheetId = _context.Timesheets.Add(timesheet);
            _context.SaveChanges();

            return timesheetId.Entity.Id;
        }

        public void UpdateTimesheet(BusyTime exitingTimesheet, BusyTime timesheetToUpdate)
        {
            exitingTimesheet.Start = timesheetToUpdate.Start;
            exitingTimesheet.End = timesheetToUpdate.End;
            exitingTimesheet.Weekday = timesheetToUpdate.Weekday;
            _context.SaveChanges();
        }

        public void RestoreOrDeleteTimesheet(Timesheet timesheet, bool IsDeleted)
        {
            timesheet.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }

        public List<Timesheet> GetTimesheetBySitterId(int id)
        {
            var result = _context.Timesheets.Where(w => w.Sitter.Id == id).ToList();
            return result;
        }

    }
}
