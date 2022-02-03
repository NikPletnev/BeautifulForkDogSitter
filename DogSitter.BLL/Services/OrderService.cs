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
    public class OrderService
    {
        private readonly OrderRepository _repository;
        public OrderService()
        {
            _repository = new OrderRepository();
        }

        public OrderModel GetById(int id)
        {
            try
            {
                var order = _repository.GetById(id);
                return CustomMapper.GetInstance().Map<OrderModel>(order);
            }
            catch (Exception)
            {

                throw new Exception("Заказ не найден");
            }
        }

        public List<OrderModel> GetAll()
        {
            var orders = _repository.GetAll();
            return CustomMapper.GetInstance().Map<List<OrderModel>>(orders);
        }

        public void Add(OrderModel orderModel)
        {
            var order = CustomMapper.GetInstance().Map<Order>(orderModel);
            _repository.Add(order);
        }

        public void Update(OrderModel orderModel)
        {
            var order = CustomMapper.GetInstance().Map<Order>(orderModel);
            try
            {
                var entity = _repository.GetById(orderModel.Id);

            }
            catch (Exception)
            {

                throw new Exception("Заказ не найден");
            }
            _repository.Update(order);
        }

        public void DeleteById(int id)
        {
            try
            {
                var entity = _repository.GetById(id);

            }
            catch (Exception)
            {

                throw new Exception("Заказ не найден");
            }
            bool delete = true;
            _repository.Update(id, delete);
        }

        public void Restore(int id)
        {
            try
            {
                var entity = _repository.GetById(id);

            }
            catch (Exception)
            {

                throw new Exception("Заказ не найден");
            }
            bool Delete = false;
            _repository.Update(id, Delete);
        }
    }
}
