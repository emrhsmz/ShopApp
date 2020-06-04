using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EntityFramework.Context;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EfOrderRepository : EfGenericRepository<Order, ShopContext>, IOrderRepository
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context = new ShopContext())
            {
                var orders = context.Orders
                    .Include(i => i.OrderItems)
                    .ThenInclude(i => i.Product)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i => i.UserId == userId);
                }
                return orders.ToList();
            };
        }
    }
}
