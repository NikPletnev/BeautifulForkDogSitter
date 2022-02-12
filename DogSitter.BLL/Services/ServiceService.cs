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
                throw new EntityNotFoundException($"{service} c Id = {id} не найден!");

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
            var service = _mapper.Map<Serviсe>(serviceModel);

            if (_serviceRepository.GetServiceById(service.Id) == null)
                throw new EntityNotFoundException($"{service} не найден!");

            _serviceRepository.UpdateService(service);
        }

        public void DeleteService(ServiceModel serviceModel)
        {
            var service = _mapper.Map<Serviсe>(serviceModel);

            if (_serviceRepository.GetServiceById(service.Id) == null)
                throw new EntityNotFoundException($"{service} не найден!");

            _serviceRepository.UpdateService(service, true);
        }
    }
}

