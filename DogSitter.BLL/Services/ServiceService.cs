using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class ServiceService
    {
        private ServiceRepository _repository;
        private readonly IMapper _mapper;

        public ServiceService()
        {
            _repository = new ServiceRepository();
            _mapper = CustomMapper.GetInstance();
        }

        public ServiceModel GetServiceById(int id)
        {
            try
            {
                var service = _repository.GetServiceById(id);
                return _mapper.Map<ServiceModel>(service);
            }
            catch (Exception)
            {
                throw new Exception("Сервис не найден!");
            }
        }

        public List<ServiceModel> GetAllServices()
        {
            var services = _repository.GetAllServices();
            return _mapper.Map<List<ServiceModel>>(services);
        }

        public void AddService(ServiceModel serviceModel)
        {
            var service = _mapper.Map<Serviсe>(serviceModel);

            _repository.AddService(service);
        }

        public void UpdateService(ServiceModel serviceModel)
        {
            var service = _mapper.Map<Serviсe>(serviceModel);
            try
            {
                var entity = _repository.GetServiceById(serviceModel.Id);
            }
            catch (Exception)
            {
                throw new Exception("Сeрвис не найден!");
            }

            _repository.UpdateService(service);
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

