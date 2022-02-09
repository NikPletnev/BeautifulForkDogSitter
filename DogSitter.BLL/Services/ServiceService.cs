using AutoMapper;
using DogService.BLL.Services;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public ServiceModel GetServiceById(int id)
        {
            var service = _serviceRepository.GetServiceById(id);

            if (service == null)
                throw new Exception("Сервис не найден!");

            return _mapper.Map<ServiceModel>(service);
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

        public void UpdateService(int id, ServiceModel serviceModel)
        {
            var entity = _mapper.Map<Serviсe>(serviceModel);
            var service = _serviceRepository.GetServiceById(id);

            if (service == null)
                throw new Exception("Сервис не найден");

            _serviceRepository.UpdateService(entity);
        }

        public void DeleteService(int id)
        {
            var entity = _serviceRepository.GetServiceById(id);

            if (entity == null)
                throw new Exception("Сeрвис не найден!");

            _serviceRepository.UpdateService(id, true);
        }

        public void RestoreService(int id)
        {
            var entity = _serviceRepository.GetServiceById(id);

            if (entity == null)
                throw new Exception("Сeрвис не найден!");

            _serviceRepository.UpdateService(id, false);
        }
    }
}

