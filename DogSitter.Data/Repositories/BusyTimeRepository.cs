using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class BusyTimeRepository : IBusyTimeRepository
    {
        private readonly DogSitterContext _context;

        public BusyTimeRepository(DogSitterContext context)
        {
            _context = context;
        }

        public BusyTime GetBusyTimeById(int id) =>
                     _context.BusyTimes.FirstOrDefault(w => w.Id == id);

        public int AddBusyTime(BusyTime busyTime, Sitter sitter)
        {
            busyTime.Sitter = sitter;

            if (sitter.BusyTime == null)
            {
                sitter.BusyTime = new List<BusyTime>();
            }

            sitter.BusyTime.Add(busyTime);
            var workTimeId = _context.BusyTimes.Add(busyTime);
            _context.SaveChanges();

            return workTimeId.Entity.Id;
        }

        public void UpdateBusyTime(BusyTime exitingBusyTime, BusyTime busyTimeToUpdate)
        {
            exitingBusyTime.Start = busyTimeToUpdate.Start;
            exitingBusyTime.End = busyTimeToUpdate.End;
            exitingBusyTime.Weekday = busyTimeToUpdate.Weekday;
            _context.SaveChanges();
        }

        public void DeleteBusyTime(BusyTime busyTime)
        {
            _context.BusyTimes.Remove(busyTime);
            _context.SaveChanges();
        }

        public List<BusyTime> GetBusyTimeBySitterId(int id)
        {
            var result = _context.BusyTimes.Where(w => w.Sitter.Id == id).ToList();
            return result;
        }

    }
}
