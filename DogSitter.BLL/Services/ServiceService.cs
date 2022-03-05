using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ISitterRepository _sitterRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository,
            ISitterRepository sitterRepository, IUserRepository userRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _sitterRepository = sitterRepository;
            _userRepository = userRepository;
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

        public int AddService(int userId, ServiceModel serviceModel)
        {
            var service = _mapper.Map<Serviсe>(serviceModel);

            var user = _userRepository.GetUserById(userId);
            service.Sitter = (Sitter)user;

            return _serviceRepository.AddService(service);
        }

        public void UpdateService(int userId, int id, ServiceModel serviceModel)
        {
            var serviceToUpdate = _mapper.Map<Serviсe>(serviceModel);

            var exitingService = _serviceRepository.GetServiceById(id);

            if (exitingService is null)
                throw new EntityNotFoundException("Service wasn't found");

            if (_userRepository.GetUserById(userId).Role != Role.Admin && exitingService.Sitter.Id != userId)
            {
                throw new AccessException("Not enough rights");
            }

            _serviceRepository.UpdateService(exitingService, serviceToUpdate);
        }

        public void DeleteService(int userId, int id)
        {
            var serviceToDelete = _serviceRepository.GetServiceById(id);

            if (serviceToDelete is null)
            {
                throw new EntityNotFoundException("Subway station wasn't found");
            }

            if (_userRepository.GetUserById(userId).Role != Role.Admin && serviceToDelete.Sitter.Id != userId)
            {
                throw new AccessException("Not enough rights");
            }

            _serviceRepository.UpdateOrDeleteService(serviceToDelete, true);
        }

        public void RestoreService(int id)
        {
            var serviceToRestore = _serviceRepository.GetServiceById(id);

            if (serviceToRestore is null)
            {
                throw new EntityNotFoundException("Subway station wasn't found");
            }

            _serviceRepository.UpdateOrDeleteService(serviceToRestore, true);
        }

        public List<ServiceModel> GetAllServicesBySitterId(int userId, int id)
        {
            var sitter = _sitterRepository.GetById(id);
            var user = _userRepository.GetUserById(userId);
            if (sitter is null)
            {
                throw new EntityNotFoundException($"Sitter wasn't found");
            }

            if (user.Role == Role.Sitter && sitter.Id != userId)
            {
                throw new AccessException("Not enough rights");
            }

            return _mapper.Map<List<ServiceModel>>(_serviceRepository.GetAllServicesBySitterId(id));
        }
    }
}

