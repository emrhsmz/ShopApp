using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Business.Abstract
{
    public interface IOrderService
    {
        Order GetById(int id);
        List<Order> GetAll();
        List<Order> GetOrders(string userId);
        void Create(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
    }
}
