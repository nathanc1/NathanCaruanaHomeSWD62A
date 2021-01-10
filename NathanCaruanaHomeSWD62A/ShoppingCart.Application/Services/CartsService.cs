using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CartsService : ICartsService
    {
        private ICartsRepository _cartRepo;
        public CartsService(ICartsRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        public void AddCart(CartViewModel data)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartViewModel> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
