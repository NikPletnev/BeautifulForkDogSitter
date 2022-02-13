using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IWorkTimeRepository
    {
        void AddWorkTime(WorkTime workTime);
        List<WorkTime> GetAllWorkTimes();
        WorkTime GetWorkTimeById(int id);
        void UpdateWorkTime(WorkTime workTime);
        void UpdateWorkTime(WorkTime workTime, bool IsDeleted);
        void RestoreWorkTime(WorkTime workTime, bool IsDeleted);

    }
}