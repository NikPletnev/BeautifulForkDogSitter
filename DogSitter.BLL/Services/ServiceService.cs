using DogSitter.BLL.Config;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogService.BLL.Services
{
    public class ServiceService
    {
        private ServiceRepository _repository;

        public ServiceService()
        {
            _repository = new ServiceRepository();
        }

        public ServiceModel GetServiceById(int id)
        {
            try
            {
                var Service = _repository.GetServiceById(id);
                return CustomMapper.GetInstance().Map<ServiceModel>(Service);
            }
            catch (Exception)
            {
                throw new Exception("Сервис не найден!");
            }
        }

        public List<ServiceModel> GetAllServices()
        {
            var Services = _repository.GetAllServices();
            return CustomMapper.GetInstance().Map<List<ServiceModel>>(Services);
        }

        public void AddService(ServiceModel ServiceModel)
        {
            var Service = CustomMapper.GetInstance().Map<Serviсe>(ServiceModel);

            _repository.AddService(Service);
        }

        public void UpdateService(ServiceModel ServiceModel)
        {
            var Service = CustomMapper.GetInstance().Map<Serviсe>(ServiceModel);
            try
            {
                var entity = _repository.GetServiceById(ServiceModel.Id);
            }
            catch (Exception)
            {

                throw new Exception("Сeрвис не найден!");
            }

            _repository.UpdateService(Service);
        }

        public void UpdateService(int id)
        {
            try
            {
                var entity = _repository.GetServiceById(id);
            }
            catch (Exception)
            {
                throw new Exception("Сeрвис не найден!");
            }
            bool delete = true;

            _repository.UpdateService(id, delete);
        }

        public void RestoreService(int id)
        {
            try
            {
                var entity = _repository.GetServiceById(id);
            }
            catch (Exception)
            {
                throw new Exception("Сeрвис не найден!");
            }
            bool Delete = false;

            _repository.UpdateService(id, Delete);
        }
    }
}

