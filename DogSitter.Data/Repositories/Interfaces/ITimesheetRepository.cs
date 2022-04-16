using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface ITimesheetRepository
    {
        int AddTimesheet(Timesheet timesheet, Sitter sitter);
        Timesheet GetTimesheetById(int id);
        List<Timesheet> GetTimesheetBySitterId(int id);
        void RestoreOrDeleteTimesheet(Timesheet timesheet, bool IsDeleted);
        void UpdateTimesheet(Timesheet exitingTimesheet, Timesheet timesheetToUpdate);
    }
}