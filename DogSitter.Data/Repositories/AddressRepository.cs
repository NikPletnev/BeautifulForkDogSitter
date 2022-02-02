﻿using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Repositories
{
    public class AddressRepository
    {

        private DogSitterContext _context;

        public AddressRepository()
        {
            _context = DogSitterContext.GetInstance();
        }

        public Address GetAddressById(int id) =>
             _context.Addresses.FirstOrDefault(x => x.Id == id);

        public List<Address> GetAllAddress() =>
            _context.Addresses.Where(d => !d.IsDeleted).ToList();

        public void AddAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }


        public void UpdateAddress(Address address)
        {
            var entity = GetAddressById(address.Id);
            entity.Name = address.Name;
            entity.City = address.City;
            entity.Street = address.Street;
            entity.House = address.House;
            entity.Apartament = address.Apartament;
            entity.SubwayStations = address.SubwayStations;
            _context.SaveChanges();
        }

        public void DeleteAddressById(int id)
        {
            var address = GetAddressById(id);
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

        public void UpdateAddress(int id, bool IsDeleted)
        {
            Address address = GetAddressById(id);
            address.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }

    }
}