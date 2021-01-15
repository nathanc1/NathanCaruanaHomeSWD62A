using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private ShoppingCartDBContext _context;
        public OrdersRepository(ShoppingCartDBContext context)
        {
            _context = context;
        }
        public void AddOrder(Order o)
        {
            _context.Orders.Add(o);
            _context.SaveChanges();
        }
    }
}
