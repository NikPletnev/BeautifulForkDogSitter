using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IWorkTimeService
    {
        void AddWorkTime(WorkTimeModel workTimeModel);
        void DeleteWorkTime(int id);
        WorkTimeModel GetWorkTimeById(int id);
        void UpdateWorkTime(int id, WorkTimeModel workTimeModel);
        void RestoreWorkTime(int id);
    }
}