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
        private IMapper _mapper;
        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepo, IMapper mapper)
        {
            _ordersDetailsRepo = orderDetailsRepo;
            _mapper = mapper;
        }
        public void AddOrderDetails(OrderDetailViewModel data)
        {
            OrderDetails ord = new OrderDetails();

            ord.OrderFk = data.Order.Id;
            ord.ProductFk = data.Product.Id;
            ord.Quantity = data.Quantity;


            _ordersDetailsRepo.AddOrderDetails(ord);

            //ord.ProductFk = od.Product.Id;
            //  ord.Quantity = od.Quantity;
        }
        public OrderDetailViewModel GetOrder(Guid id)
        {
            OrderDetails orderDetails = _ordersDetailsRepo.GetOrder(id);
            var resultingOrderDetailsViewModel = _mapper.Map<OrderDetailViewModel>(orderDetails);
            return resultingOrderDetailsViewModel;

            /*OrderDetailViewModel myViewModel = new OrderDetailViewModel();
            var productFromDb = _ordersDetailsRepo.GetOrder(id);

            myViewModel.Order.Id = productFromDb.Order.Id;
            return myViewModel;
            */
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
