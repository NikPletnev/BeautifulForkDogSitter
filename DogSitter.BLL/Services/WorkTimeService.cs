using DogSitter.BLL.Config;
using DogSitter.BLL.Models;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Entity;

namespace DogSitter.BLL.WorkTimes
{
    public class WorkTimeService
    {
        private WorkTimeRepository _repository;

        public WorkTimeService()
        {
            _repository = new WorkTimeRepository();
        }

        public WorkTimeModel GetWorkTimeById(int id)
        {
            try
            {
                var WorkTime = _repository.GetWorkTimeById(id);
                return CustomMapper.GetInstance().Map<WorkTimeModel>(WorkTime);
            }
            catch (Exception)
            {
                throw new Exception("Рабочее время не найдено!");
            }
        }

        public List<WorkTimeModel> GetAllWorkTimes()
        {
            var WorkTimes = _repository.GetAllWorkTimes();
            return CustomMapper.GetInstance().Map<List<WorkTimeModel>>(WorkTimes);
        }

        public void AddWorkTime(WorkTimeModel WorkTimeModel)
        {
            var WorkTime = CustomMapper.GetInstance().Map<WorkTime>(WorkTimeModel);

            _repository.AddWorkTime(WorkTime);
        }

        public void UpdateWorkTime(WorkTimeModel WorkTimeModel)
        {
            var WorkTime = CustomMapper.GetInstance().Map<WorkTime>(WorkTimeModel);
            try
            {
                var entity = _repository.GetWorkTimeById(WorkTimeModel.Id);
            }
            catch (Exception)
            {

                throw new Exception("Рабочее время не найдено!");
            }

            _repository.UpdateWorkTime(WorkTime);
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
