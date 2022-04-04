using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class BusyTimeService 
    {
        private readonly IBusyTimeRepository _busyTimeRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public BusyTimeService(IBusyTimeRepository busyTimeRepository, IMapper mapper, IUserRepository userRepository)
        {
            _busyTimeRepository = busyTimeRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public int AddBusyTime(int userId, BusyTimeModel busyTimeModel)
        {
            var sitter = (Sitter)_userRepository.GetUserById(userId);
            var busyTime = _mapper.Map<BusyTime>(busyTimeModel);
            int id = _busyTimeRepository.AddBusyTime(busyTime, sitter);
            return id;
        }

        public void UpdateBusyTime(int userId, int id, BusyTimeModel busyTimeModel)
        {
            var exitingBusyTime = _busyTimeRepository.GetBusyTimeById(id);
            if (exitingBusyTime is null)
                throw new EntityNotFoundException($"BusyTime wasn't found!");
            if (exitingBusyTime.Sitter.Id != userId)
            {
                throw new AccessException("Not enough rights");
            }
            var busyTimeToUpdate = _mapper.Map<BusyTime>(busyTimeModel);


            _busyTimeRepository.UpdateBusyTime(exitingBusyTime, busyTimeToUpdate);
        }

        public void DeleteBusyTime(int userId, int id)
        {
            var busyTime = _busyTimeRepository.GetBusyTimeById(id);
            if (busyTime is null)
                throw new EntityNotFoundException($"BusyTime wasn't found!");
            if (busyTime.Sitter.Id != userId)
            {
                throw new AccessException("Not enough rights");
            }

            _busyTimeRepository.DeleteBusyTime(busyTime);
        }

        public List<BusyTimeModel> GetBusyTimeBySitterId(int id)
        {
            var busyTimeList = _busyTimeRepository.GetBusyTimeById(id);
            return _mapper.Map<List<BusyTimeModel>>(busyTimeList);
        }

        public BusyTimeModel GetBusyTimeById(int id)
        {
            var busyTime = _busyTimeRepository.GetBusyTimeById(id);
            if (busyTime is null)
            {
                throw new EntityNotFoundException($"BusyTime wasn't found!");
            }
            return _mapper.Map<BusyTimeModel>(busyTime);
        }
    }
}
