using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.WorkTimes
{
    public class WorkTimeService : IWorkTimeService
    {
        private WorkTimeRepository _repository;
        private IMapper _mapper;

        public WorkTimeService(IMapper mapper)
        {
            _repository = new WorkTimeRepository();
            _mapper = mapper;
        }

        public WorkTimeModel GetWorkTimeById(int id)
        {
            try
            {
                var workTime = _repository.GetWorkTimeById(id);
                return _mapper.GetInstance().Map<WorkTimeModel>(workTime);
            }
            catch (Exception)
            {
                throw new Exception("Рабочее время не найдено!");
            }
        }

        public List<WorkTimeModel> GetAllWorkTimes()
        {
            var workTimes = _repository.GetAllWorkTimes();
            return _mapper.GetInstance().Map<List<WorkTimeModel>>(workTimes);
        }

        public void AddWorkTime(WorkTimeModel workTimeModel)
        {
            var workTime = _mapper.GetInstance().Map<WorkTime>(workTimeModel);

            _repository.AddWorkTime(workTime);
        }

        public void UpdateWorkTime(WorkTimeModel workTimeModel)
        {
            var workTime = _mapper.GetInstance().Map<WorkTime>(workTimeModel);
            try
            {
                var entity = _repository.GetWorkTimeById(workTimeModel.Id);
            }
            catch (Exception)
            {
                throw new Exception("Рабочее время не найдено!");
            }

            _repository.UpdateWorkTime(workTime);
        }

        public void UpdateWorkTime(int id)
        {
            try
            {
                var entity = _repository.GetWorkTimeById(id);
            }
            catch (Exception)
            {
                throw new Exception("Рабочее время не найдено!");
            }
            bool delete = true;

            _repository.UpdateWorkTime(id, delete);
        }

        public void RestoreWorkTime(int id)
        {
            try
            {
                var entity = _repository.GetWorkTimeById(id);
            }
            catch (Exception)
            {
                throw new Exception("Рабочее время не найдено!");
            }
            bool Delete = false;

            _repository.UpdateWorkTime(id, Delete);
        }
    }
}
