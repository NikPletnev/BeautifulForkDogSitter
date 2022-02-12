using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IWorkTimeRepository
    {
        void AddWorkTime(WorkTime workTime);
        void DeleteWorkTime(int id);
        List<WorkTime> GetAllWorkTimes();
        WorkTime GetWorkTimeById(int id);
        void UpdateWorkTime(int id, bool IsDeleted);
        void UpdateWorkTime(WorkTime workTime);
    }
}