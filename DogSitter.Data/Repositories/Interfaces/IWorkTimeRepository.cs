using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IWorkTimeRepository
    {
        int AddWorkTime(WorkTime workTime);
        WorkTime GetWorkTimeById(int id);
        void UpdateWorkTime(WorkTime exitingWorkTime, WorkTime workTimeToUpdate);
        void UpdateOrDeleteWorkTime(WorkTime workTime, bool IsDeleted);
    }
}