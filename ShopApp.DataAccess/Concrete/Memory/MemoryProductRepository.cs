using ShopApp.DataAccess.Abstract;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Concrete.Memory
{
    public class MemoryProductRepository : IProductRepository
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Samsung S2", ImageURL = "1.jpg",Price =1000 },
                new Product() { Id = 2, Name = "Samsung S3", ImageURL = "2.jpg",Price =2000 },
                new Product() { Id = 3, Name = "Samsung S4", ImageURL = "3.jpg",Price =3000 },
                new Product() { Id = 4, Name = "Samsung S5", ImageURL = "4.jpg",Price =4000 },
                new Product() { Id = 5, Name = "Samsung S6", ImageURL = "5.jpg",Price =5000 }
            };
            return products;

        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Product GetOne(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Product GetProductDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
