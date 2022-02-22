using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IWorkTimeService
    {
        void AddWorkTime(int userId, WorkTimeModel workTimeModel);
        void DeleteWorkTime(int userId, int id);
        void UpdateWorkTime(int userId, int id, WorkTimeModel workTimeModel);
        void RestoreWorkTime(int id);
    }
}