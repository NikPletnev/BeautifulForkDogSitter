using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ISitterRepository _sitterRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository, 
            ISitterRepository sitterRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _sitterRepository = sitterRepository;
            _mapper = mapper;
        }

        public ServiceModel GetServiceById(int id)
        {
            var service = _serviceRepository.GetServiceById(id);

            if (service is null)
                throw new EntityNotFoundException($"Service wasn't found");

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

        public void UpdateService(ServiceModel serviceModel)
        {
            var exitingService = _mapper.Map<Serviсe>(serviceModel);

            if (_serviceRepository.GetServiceById(exitingService.Id) is null)
                throw new EntityNotFoundException($"Service {exitingService.Name} wasn't found");

            var serviceToUpdate = _mapper.Map<Serviсe>(exitingService);

            _serviceRepository.UpdateService(exitingService, serviceToUpdate);
        }

        public void DeleteService(ServiceModel serviceModel)
        {
            var service = _mapper.Map<Serviсe>(serviceModel);

            if (_serviceRepository.GetServiceById(service.Id) is null)
                throw new EntityNotFoundException($" Service {service.Name} wasn't found");

            _serviceRepository.UpdateOrDeleteService(service, true);
        }

        public void RestoreService(ServiceModel serviceModel)
        {
            var service = _mapper.Map<Serviсe>(serviceModel);

            if (_serviceRepository.GetServiceById(service.Id) is null)
                throw new EntityNotFoundException($"Сервис {service.Name} wasn't found");

            _serviceRepository.UpdateOrDeleteService(service, false);
        }

        public List<ServiceModel> GetAllServicesBySitterId(int id)
        {
            var sitter = _sitterRepository.GetById(id);

            if (sitter is null)
                throw new EntityNotFoundException($"Sitter wasn't found");

            return _mapper.Map<List<ServiceModel>>(_serviceRepository.GetAllServicesBySitterId(id));
        }
    }
}

