﻿using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class WorkTimeRepository : IWorkTimeRepository
    {
        private readonly DogSitterContext _context;
        private bool _isInitialized;
        public WorkTimeRepository(DogSitterContext dbContext)
        {
            _isInitialized = true;
            _context = dbContext;
        }

        public List<WorkTime> GetAllWorkTimes() =>
            _context.WorkTimes.Where(w => !w.IsDeleted).ToList();

        public WorkTime GetWorkTimeById(int id) =>
            _context.WorkTimes.FirstOrDefault(w => w.Id == id);

        public void AddWorkTime(WorkTime workTime)
        {
            _context.WorkTimes.Add(workTime);
            _context.SaveChanges();
        }

        public void UpdateWorkTime(WorkTime workTime)
        {
            var trackingWorkTime = _context.ChangeTracker.Entries<WorkTime>()
                  .First(a => a.Entity.Id == workTime.Id).Entity;

            trackingWorkTime.Start = workTime.Start;
            trackingWorkTime.End = workTime.End;
            trackingWorkTime.Weekday = workTime.Weekday;
            trackingWorkTime.Sitter = workTime.Sitter;
            _context.SaveChanges();
        }

        public void UpdateWorkTime(WorkTime workTime, bool IsDeleted)
        {
            workTime.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }

        public void RestoreWorkTime(WorkTime workTime, bool IsDeleted)
        {
            workTime.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}
