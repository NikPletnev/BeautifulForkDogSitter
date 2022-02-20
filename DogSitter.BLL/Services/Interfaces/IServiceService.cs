﻿using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IServiceService
    {
        void AddService(ServiceModel serviceModel);
        List<ServiceModel> GetAllServices();
        List<ServiceModel> GetAllServicesBySitterId(int id);
        ServiceModel GetServiceById(int id);
        void DeleteService(ServiceModel serviceModel);
        void UpdateService(ServiceModel serviceModel);
        void RestoreService(ServiceModel serviceModel);
    }
}