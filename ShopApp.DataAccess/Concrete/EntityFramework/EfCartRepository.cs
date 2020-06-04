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
    public class EfCartRepository : EfGenericRepository<Cart, ShopContext>, ICartRepository
    {
        public override void Update(Cart entity)
        {
            using (var context = new ShopContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            };
        }

        public Cart GetCartByUserId(string userId)
        {
            using (var context = new ShopContext())
            {
                return context
                    .Carts
                    .Include(i => i.CartItems)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault(i => i.UserId == userId);
            }
        }

        public void DeleteFromCart(int cartId, int productId)
        {
            using (var context = new ShopContext())
            {
                var cmd = @"DELETE FROM CartItem WHERE CartID=@p0 AND ProductID =@p1";
                context.Database.ExecuteSqlCommand(cmd, cartId, productId);
            }
        }

        public void ClearCart(string cartId)
        {
            using (var context = new ShopContext())
            {
                var cmd = @"DELETE FROM CartItem WHERE CartID=@p0";
                context.Database.ExecuteSqlCommand(cmd, cartId);
            }
        }
    }
}