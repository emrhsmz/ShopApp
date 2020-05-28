using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Abstract
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }
}
