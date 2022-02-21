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

        public WorkTimeService(IWorkTimeRepository workTimeRepository, IMapper mapper)
        {
            _workTimeRepository = workTimeRepository;
            _mapper = mapper;
        }

        public WorkTimeModel GetWorkTimeById(int id)
        {
            var workTime = _workTimeRepository.GetWorkTimeById(id);

            if (workTime is null)
                throw new EntityNotFoundException($"WorkTime wasn't found");

            return _mapper.Map<WorkTimeModel>(workTime);
        }

        public void AddWorkTime(WorkTimeModel workTimeModel)
        {
            var workTime = _mapper.Map<WorkTime>(workTimeModel);

            _workTimeRepository.AddWorkTime(workTime);
        }

        public void UpdateWorkTime(WorkTimeModel workTimeModel)
        {
            var exitingworkTime = _mapper.Map<WorkTime>(workTimeModel);

            if (_workTimeRepository.GetWorkTimeById(exitingworkTime.Id) is null)
                throw new EntityNotFoundException($"WorkTime wasn't found!");

            var workTimeToUpdate = _mapper.Map<WorkTime>(workTimeModel);

            _workTimeRepository.UpdateWorkTime(exitingworkTime, workTimeToUpdate);
        }

        public void DeleteWorkTime(WorkTimeModel workTimeModel)
        {
            var workTime = _mapper.Map<WorkTime>(workTimeModel);

            if (_workTimeRepository.GetWorkTimeById(workTime.Id) is null)
                throw new EntityNotFoundException($"WorkTime wasn't found!");

            _workTimeRepository.UpdateOrDeleteWorkTime(workTime, true);
        }

        public void RestoreWorkTime(WorkTimeModel workTimeModel)
        {
            var workTime = _mapper.Map<WorkTime>(workTimeModel);

            if (_workTimeRepository.GetWorkTimeById(workTime.Id) is null)
                throw new EntityNotFoundException($"WorkTime wasn't found!");

            _workTimeRepository.UpdateOrDeleteWorkTime(workTime, false);
        }
    }
}
