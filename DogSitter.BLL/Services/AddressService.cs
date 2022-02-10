﻿using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class AddressService : IAddressService
    {
        private AddressRepository _repository;
        private IMapper _mapper;

        public AddressService(IMapper mapper)
        {
            _repository = new AddressRepository();
            _mapper = mapper;
        }

        public AddressModel GetAddressById(int id)
        {
            var address = _repository.GetAddressById(id);
            if (address == null)
            {
                throw new Exception("Адресс не найден");

            }
            return _mapper.Map<AddressModel>(address);
        }

        public List<AddressModel> GetAllAddresses()
        {
            var address = _repository.GetAllAddress();
            return _mapper.Map<List<AddressModel>>(address);
        }

        public void AddAddress(AddressModel address)
        {
            var addressModel = _mapper.Map<Address>(address);
            _repository.AddAddress(addressModel);
        }

        public void UpdateAddress(AddressModel address)
        {
            var addressModel = _mapper.Map<Address>(address);
            var entity = _repository.GetAddressById(address.Id);
            if (entity == null)
            {
                throw new Exception("Адресс не найден");

            }
            _repository.UpdateAddress(addressModel);
        }

        public void DeleteAddressById(int id)
        {
            var entity = _repository.GetAddressById(id);
            if (entity == null)
            {
                throw new Exception("Адресс не найден");
            }
            _repository.UpdateAddress(id, true);
        }

        public void RestoreAddress(int id)
        {
            var entity = _repository.GetAddressById(id);
            if (entity == null)
            {
                throw new Exception("Адресс не найден");
            }
            _repository.UpdateAddress(id, false);
        }
    }
}