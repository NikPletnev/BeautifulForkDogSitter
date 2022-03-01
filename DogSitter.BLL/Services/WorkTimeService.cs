using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class WorkTimeService : IWorkTimeService
    {
        private readonly IWorkTimeRepository _workTimeRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public WorkTimeService(IWorkTimeRepository workTimeRepository, IMapper mapper, IUserRepository userRepository)
        {
            _workTimeRepository = workTimeRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void AddWorkTime(int userId, WorkTimeModel workTimeModel)
        {
            //workTimeModel.Sitter = _mapper.Map<SitterModel>(_userRepository.GetUserById(userId));
            var sitter = (Sitter)_userRepository.GetUserById(userId);
            var workTime = _mapper.Map<WorkTime>(workTimeModel);
            _workTimeRepository.AddWorkTime(workTime, sitter);
        }

        public void UpdateWorkTime(int userId, int id, WorkTimeModel workTimeModel)
        {
            var exitingworkTime = _workTimeRepository.GetWorkTimeById(id);
            if (exitingworkTime is null)
                throw new EntityNotFoundException($"WorkTime wasn't found!");
            if (exitingworkTime.Sitter.Id != userId)
            {
                throw new AccessException("Not enough rights");
            }
            var workTimeToUpdate = _mapper.Map<WorkTime>(workTimeModel);


            _workTimeRepository.UpdateWorkTime(exitingworkTime, workTimeToUpdate);
        }

        public void DeleteWorkTime(int userId, int id)
        {
            var workTime = _workTimeRepository.GetWorkTimeById(id);
            if (workTime is null)
                throw new EntityNotFoundException($"WorkTime wasn't found!");
            if (workTime.Sitter.Id != userId)
            {
                throw new AccessException("Not enough rights");
            }

            _workTimeRepository.UpdateOrDeleteWorkTime(workTime, true);
        }

        public void RestoreWorkTime(int id)
        {
            var workTime = _workTimeRepository.GetWorkTimeById(id);

            if (workTime is null)
                throw new EntityNotFoundException($"WorkTime wasn't found!");

            _workTimeRepository.UpdateOrDeleteWorkTime(workTime, false);
        }

        public List<WorkTimeModel> GetWorkTimeBySitterId( int id)
        {
            var workTimeList = _workTimeRepository.GetWorkTimeById(id);
            return _mapper.Map<List<WorkTimeModel>>(workTimeList);
        }
    }
}
