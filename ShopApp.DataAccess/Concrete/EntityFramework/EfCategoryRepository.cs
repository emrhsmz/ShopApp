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
    public class EfCategoryRepository : EfGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public void DeleteFromCategory(int id, int categoryId)
        {
            using (var context = new ShopContext()) 
            {
                var cmd = @"delete from ProductCategory where ProductId=@p0 and CategoryId = @p1";
                context.Database.ExecuteSqlCommand(cmd, id, categoryId);
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Categories
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault();
            }
        }
    }
}
