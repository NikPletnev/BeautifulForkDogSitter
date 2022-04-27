using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class TimesheetService : ITimesheetService
    {
        private readonly ITimesheetRepository _timesheetRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public TimesheetService(ITimesheetRepository timesheetRepository, IMapper mapper, IUserRepository userRepository)
        {
            _timesheetRepository = timesheetRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public int AddTimesheet(int userId, TimesheetModel timesheetModel)
        {
            var sitter = (Sitter)_userRepository.GetUserById(userId);
            var workTime = _mapper.Map<Timesheet>(timesheetModel);
            int id = _timesheetRepository.AddTimesheet(workTime, sitter);
            return id;
        }

        public void UpdateTimesheet(int userId, int id, TimesheetModel timesheetModel)
        {
            var exitingTimesheet = _timesheetRepository.GetTimesheetById(id);
            if (exitingTimesheet is null)
                throw new EntityNotFoundException($"Timesheet wasn't found!");
            if (exitingTimesheet.Sitter.Id != userId)
            {
                throw new AccessException("Not enough rights");
            }
            var timesheetToUpdate = _mapper.Map<Timesheet>(timesheetModel);
            _timesheetRepository.UpdateTimesheet(exitingTimesheet, timesheetToUpdate);
        }

        public void DeleteTimesheet(int userId, int id)
        {
            var timesheet = _timesheetRepository.GetTimesheetById(id);
            if (timesheet is null)
                throw new EntityNotFoundException($"Timesheet wasn't found!");
            if (timesheet.Sitter.Id != userId)
            {
                throw new AccessException("Not enough rights");
            }

            _timesheetRepository.RestoreOrDeleteTimesheet(timesheet, true);
        }

        public void RestoreTimesheet(int id)
        {
            var timesheet = _timesheetRepository.GetTimesheetById(id);

            if (timesheet is null)
                throw new EntityNotFoundException($"Timesheet wasn't found!");

            _timesheetRepository.RestoreOrDeleteTimesheet(timesheet, false);
        }

        public List<TimesheetModel> GetTimesheetBySitterId(int id)
        {
            var timesheetList = _timesheetRepository.GetTimesheetById(id);
            return _mapper.Map<List<TimesheetModel>>(timesheetList);
        }

        public TimesheetModel GetTimesheetById(int id)
        {
            var timesheet = _timesheetRepository.GetTimesheetById(id);
            if (timesheet is null)
            {
                throw new EntityNotFoundException($"Timesheet wasn't found!");
            }
            return _mapper.Map<TimesheetModel>(timesheet);
        }
    }
}
