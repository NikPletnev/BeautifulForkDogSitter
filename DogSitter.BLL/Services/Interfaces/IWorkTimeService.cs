using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IWorkTimeService
    {
        void AddWorkTime(WorkTimeModel workTimeModel);
        void DeleteWorkTime(WorkTimeModel workTimeModel);
        WorkTimeModel GetWorkTimeById(int id);
        void UpdateWorkTime(WorkTimeModel workTimeModel);
        void RestoreWorkTime(WorkTimeModel workTimeModel);
    }
}