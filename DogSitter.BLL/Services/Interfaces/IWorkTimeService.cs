using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IWorkTimeService
    {
        void AddWorkTime(WorkTimeModel workTimeModel);
        List<WorkTimeModel> GetAllWorkTimes();
        WorkTimeModel GetWorkTimeById(int id);
        void RestoreWorkTime(int id);
        void DeleteWorkTime(int id);
        void UpdateWorkTime(int id, WorkTimeModel workTimeModel);
    }
}