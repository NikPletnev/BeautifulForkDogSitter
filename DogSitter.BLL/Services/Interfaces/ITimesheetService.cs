using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface ITimesheetService
    {
        int AddTimesheet(int userId, TimesheetModel timesheetModel);
        void DeleteTimesheet(int userId, int id);
        TimesheetModel GetTimesheetById(int id);
        List<TimesheetModel> GetTimesheetBySitterId(int id);
        void RestoreTimesheet(int id);
        void UpdateTimesheet(int userId, int id, TimesheetModel timesheetModel);
    }
}