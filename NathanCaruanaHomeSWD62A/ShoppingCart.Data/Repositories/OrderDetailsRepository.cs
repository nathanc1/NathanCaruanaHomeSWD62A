using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private ShoppingCartDBContext _context;
        public OrderDetailsRepository(ShoppingCartDBContext context)
        {
            _context = context;
        }
        public void AddOrderDetails(OrderDetails od)
        {
            _context.OrderDetails.Add(od);
            _context.SaveChanges();
        }

        public OrderDetails GetOrder(Guid id)
        {
            return _context.OrderDetails.SingleOrDefault(x => x.Order.Id == id);
        }

        public IQueryable<OrderDetails> GetProdsCart(Guid id, string email)
        {
            return _context.OrderDetails;
        }
    }
}
