using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private IOrdersRepository _ordersRepo;
        public OrdersService(IOrdersRepository ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }
        public void AddOrder(OrderViewModel o, string email)
        {
            Order or = new Order();
            or.OrderDate = System.DateTime.Now;
            or.Email = email;
            _ordersRepo.AddOrder(or);
        }
    }
}
