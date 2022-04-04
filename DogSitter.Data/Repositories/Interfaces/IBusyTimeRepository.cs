using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IBusyTimeRepository
    {
        int AddBusyTime(BusyTime busyTime, Sitter sitter);
        BusyTime GetBusyTimeById(int id);
        List<BusyTime> GetBusyTimeBySitterId(int id);
        void UpdateBusyTime(BusyTime exitingBusyTime, BusyTime busyTimeToUpdate);
        void DeleteBusyTime(BusyTime busyTime);
    }
}