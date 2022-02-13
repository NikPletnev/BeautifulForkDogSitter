using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IWorkTimeService
    {
        void AddWorkTime(WorkTimeModel workTimeModel);
        void DeleteWorkTime(WorkTimeModel workTimeModel);
        List<WorkTimeModel> GetAllWorkTimes();
        WorkTimeModel GetWorkTimeById(int id);
        void UpdateWorkTime(WorkTimeModel workTimeModel);
    }
}