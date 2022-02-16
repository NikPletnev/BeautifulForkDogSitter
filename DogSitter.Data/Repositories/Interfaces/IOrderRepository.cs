﻿using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order GetById(int id);
        void Update(int id, bool IsDeleted);
        void Update(Order entity, Order order);
    }
}