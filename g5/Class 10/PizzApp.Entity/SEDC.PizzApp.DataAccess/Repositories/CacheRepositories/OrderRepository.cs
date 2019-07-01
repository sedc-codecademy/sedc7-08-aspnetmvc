using SEDC.PizzApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzApp.DataAccess.Repositories.CacheRepositories
{
    public class OrderRepository : IRepository<Order>
    {
        public void DeleteById(int id)
        {
            Order order = CacheDb.Orders.FirstOrDefault(x => x.Id == id);
            if (order != null) CacheDb.Orders.Remove(order);
        }

        public List<Order> GetAll()
        {
            return CacheDb.Orders;
        }

        public Order GetById(int id)
        {
            return CacheDb.Orders.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Order entity)
        {
            CacheDb.OrderId++;
            entity.Id = CacheDb.OrderId;
            CacheDb.Orders.Add(entity);
            return entity.Id;
        }

        public void Update(Order entity)
        {
            Order order = CacheDb.Orders.FirstOrDefault(x => x.Id == entity.Id);
            if (order != null)
            {
                int index = CacheDb.Orders.IndexOf(order);
                CacheDb.Orders[index] = entity;
            }
        }
    }
}
