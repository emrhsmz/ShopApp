using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Entities.Concrete
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
