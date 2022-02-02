﻿using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class WorkTimeRepository
    {
        private DogSitterContext _context;

        public WorkTimeRepository()
        {
            _context = new DogSitterContext();
        }

        public List<WorkTime> GetAllServices() =>
                    _context.WorkTimes.Where(d => !d.IsDeleted).ToList();

        public WorkTime GetWorkTimeById(int id) =>
                     _context.WorkTimes.FirstOrDefault(x => x.Id == id);

        public void AddWorkTime(WorkTime workTime)
        {
            _context.WorkTimes.Add(workTime);
            _context.SaveChanges();
        }

        public void DeleteWorkTime(int id)
        {
            WorkTime workTime = GetWorkTimeById(id);
            _context.WorkTimes.Remove(workTime);
            _context.SaveChanges();
        }

        public void UpdateWorkTime(WorkTime workTime)
        {
            var entity = GetWorkTimeById(workTime.Id);
            entity.Start = workTime.Start;
            entity.End = workTime.End;
            entity.Weekdays = workTime.Weekdays;
            _context.SaveChanges();
        }

        public void UpdateWorkTime(int id, bool IsDeleted)
        {
            var entity = GetWorkTimeById(id);
            entity.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}
