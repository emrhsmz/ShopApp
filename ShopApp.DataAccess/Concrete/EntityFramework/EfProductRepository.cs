using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EntityFramework.Context;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EfProductRepository : EfGenericRepository<Product, ShopContext>, IProductRepository
    {
        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Count();
            }
        }

        public Product GetProductDetails(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Skip((page-1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
