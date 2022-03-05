using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IWorkTimeRepository
    {
        int AddWorkTime(WorkTime workTime, Sitter sitter);
        WorkTime GetWorkTimeById(int id);
        void UpdateWorkTime(WorkTime exitingWorkTime, WorkTime workTimeToUpdate);
        void UpdateOrDeleteWorkTime(WorkTime workTime, bool IsDeleted);
        public List<WorkTime> GetWorkTimeBySitterId(int id);
        void ChangeWorkTimeStatus(WorkTime workTime, bool isBusy);
    }
}