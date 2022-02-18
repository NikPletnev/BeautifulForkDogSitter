﻿using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IWorkTimeRepository
    {
        void AddWorkTime(WorkTime workTime);
        WorkTime GetWorkTimeById(int id);
        void UpdateWorkTime(WorkTime workTime);
        void UpdateWorkTime(WorkTime workTime, bool IsDeleted);
        void RestoreWorkTime(WorkTime workTime, bool IsDeleted);
        void DeleteWorkTime(int id);
    }
}