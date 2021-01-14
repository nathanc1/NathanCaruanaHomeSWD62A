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
        public Cart GetProduct(Guid id)
        {
            return _context.Carts.SingleOrDefault(x => x.Product.Id == id);
            //if it does not find a product with a matching id... it will return null!!
        }

        public IQueryable<Cart> GetCart()
        {
            return _context.Carts;
        }
    }
}
