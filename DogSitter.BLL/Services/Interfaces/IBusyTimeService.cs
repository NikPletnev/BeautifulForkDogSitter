using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IBusyTimeService
    {
        int AddBusyTime(int userId, BusyTimeModel busyTimeModel);
        void DeleteBusyTime(int userId, int id);
        BusyTimeModel GetBusyTimeById(int id);
        List<BusyTimeModel> GetBusyTimeBySitterId(int id);
        void UpdateBusyTime(int userId, int id, BusyTimeModel busyTimeModel);
    }
}