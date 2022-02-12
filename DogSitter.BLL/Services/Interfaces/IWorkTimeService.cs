using DogSitter.BLL.Models;

namespace DogSitter.BLL.WorkTimes
{
    public interface IWorkTimeService
    {
        void AddWorkTime(WorkTimeModel workTimeModel);
        List<WorkTimeModel> GetAllWorkTimes();
        WorkTimeModel GetWorkTimeById(int id);
        void RestoreWorkTime(int id);
        void UpdateWorkTime(int id);
        void UpdateWorkTime(WorkTimeModel workTimeModel);
    }
}