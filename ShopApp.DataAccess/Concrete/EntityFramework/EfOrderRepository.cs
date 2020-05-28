using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EntityFramework.Context;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EfOrderRepository :EfGenericRepository<Order,ShopContext> , IOrderRepository
    {
    }
}
