﻿using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IAddressRepository
    {
        void AddAddress(Address address);
        void DeleteAddressById(int id);
        Address GetAddressById(int id);
        List<Address> GetAllAddress();
        void UpdateAddress(Address address);
        void UpdateAddress(int id, bool IsDeleted);
    }
}