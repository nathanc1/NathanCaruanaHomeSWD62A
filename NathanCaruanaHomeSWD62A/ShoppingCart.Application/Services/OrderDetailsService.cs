using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private IOrderDetailsRepository _ordersDetailsRepo;
        private IOrdersRepository _ordersRepository;
        private IMapper _mapper;
        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepo, IOrdersRepository ordersRepo, IMapper mapper)
        {
            _ordersDetailsRepo = orderDetailsRepo;
            _ordersRepository = ordersRepo;
            _mapper = mapper;
        }
        public void AddOrderDetails(Guid ordid, Guid prodid,string email)
        {
            /*OrderDetails orderId = _ordersDetailsRepo.GetOrder(ordid, email);*/

            //ord.ProductFk = od.Product.Id;
            //  ord.Quantity = od.Quantity;
        }

        public IQueryable<OrderDetailViewModel> GetOrder(Guid id, string email)
        {
            var list = from p in _ordersDetailsRepo.GetOrder(id, email)
                       select new OrderDetailViewModel()
                       {
                           Order = new OrderViewModel() { Id = p.Order.Id, Email = p.Order.Email}
                       };
            return list;
        }

        public IQueryable<OrderDetailViewModel> GetProdsCart(Guid id, string email)
        {
            return _ordersDetailsRepo.GetProdsCart(id,email).ProjectTo<OrderDetailViewModel>(_mapper.ConfigurationProvider);

            /* var list = from p in _ordersDetailsRepo.GetProdsCart(id,email)
                       select new OrderDetailViewModel()
                       {
                           Order = new OrderViewModel() { Id = id, Email = email}
                       };
            return list;
            */
        }
    }
}
