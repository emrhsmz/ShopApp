using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Abstract
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Category GetByIdWithProducts(int id);
        void DeleteFromCategory(int id, int categoryId);
    }
}
