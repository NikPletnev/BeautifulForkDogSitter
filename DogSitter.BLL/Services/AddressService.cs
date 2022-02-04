using DogSitter.BLL.Config;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Services
{
    public class AddressService
    {
        private AddressRepository _repository;

        public AddressService()
        {
            _repository = new AddressRepository();
        }

        public AddressModel GetAddressById(int id)
        {
            var address = _repository.GetAddressById(id);
            if (address == null)
            {
                throw new Exception("Адресс не найден");

            }
            return CustomMapper.GetInstance().Map<AddressModel>(address);
        }

        public List<AddressModel> GetAllAddresses()
        {
            var address = _repository.GetAllAddress();
            return CustomMapper.GetInstance().Map<List<AddressModel>>(address);
        }

        public void AddAddress(AddressModel address)
        {
            var addressModel = CustomMapper.GetInstance().Map<Address>(address);
            _repository.AddAddress(addressModel);
        }

        public void UpdateAddress(AddressModel address)
        {
            var addressModel = CustomMapper.GetInstance().Map<Address>(address);
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
            bool Delete = true;
            _repository.UpdateAddress(id, Delete);
        }

        public void RestoreAddress(int id)
        {
            var entity = _repository.GetAddressById(id);
            if (entity == null)
            {
                throw new Exception("Адресс не найден");

            }
            bool Delete = false;
            _repository.UpdateAddress(id, Delete);
        }
    }
}
