using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogService.BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
            _mapper = CustomMapper.GetInstance();
        }

        public ServiceModel GetServiceById(int id)
        {
            try
            {
                var service = _serviceRepository.GetServiceById(id);
                return _mapper.Map<ServiceModel>(service);
            }
            catch (Exception)
            {
                throw new Exception("Сервис не найден!");
            }
        }

        public List<ServiceModel> GetAllServices()
        {
            var services = _serviceRepository.GetAllServices();
            return _mapper.Map<List<ServiceModel>>(services);
        }

        public void AddService(ServiceModel serviceModel)
        {
            var service = _mapper.Map<Serviсe>(serviceModel);

            _serviceRepository.AddService(service);
        }

        public void UpdateService(ServiceModel serviceModel)
        {
            var service = _mapper.Map<Serviсe>(serviceModel);
            try
            {
                var entity = _serviceRepository.GetServiceById(serviceModel.Id);
            }
            catch (Exception)
            {
                throw new Exception("Сeрвис не найден!");
            }

            _serviceRepository.UpdateService(service);
        }
        public void UpdateService(int id, ServiceModel serviceModel)
        {
            var entity = _mapper.Map<Serviсe>(serviceModel);
            var service = _serviceRepository.GetServiceById(id);
            if (service == null)
            {
                throw new Exception("Сервис не найден");
            }

            _serviceRepository.UpdateService(entity);
        }

        public void DeleteService(int id)
        {
            try
            {
                var entity = _serviceRepository.GetServiceById(id);
            }
            catch (Exception)
            {
                throw new Exception("Сeрвис не найден!");
            }
            bool delete = true;

            _serviceRepository.UpdateService(id, delete);
        }

        public void RestoreService(int id)
        {
            try
            {
                var entity = _serviceRepository.GetServiceById(id);
            }
            catch (Exception)
            {
                throw new Exception("Сeрвис не найден!");
            }
            bool Delete = false;

            _serviceRepository.UpdateService(id, Delete);
        }
    }
}

