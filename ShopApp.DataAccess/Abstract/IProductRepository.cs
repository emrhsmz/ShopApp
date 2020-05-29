using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Abstract
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        List<Product> GetProductsByCategory(string category);
        Product GetProductDetails(int id);
    }
}
