using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class CartsRepository:ICartsRepository
    {
        private ShoppingCartDBContext _context;
        public CartsRepository(ShoppingCartDBContext context)
        {
            _context = context;
        }
        public void AddCart(Cart c)
        {
            _context.Carts.Add(c);
            _context.SaveChanges();
        }
        public Cart GetCart(Guid id,string email)
        {
            return _context.Carts.SingleOrDefault(x => x.Product.Id == id && x.email == email);
        }
        public IQueryable<Cart> GetCarts()
        {
            return _context.Carts;
        }

        public void UpdateCart(Cart cart)
        {
            _context.Update(cart);
            _context.SaveChanges();
        }
    }
}
