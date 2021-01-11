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
    public class CartsService : ICartsService
    {
        private ICartsRepository _cartsRepo;
        public CartsService(ICartsRepository cartsRepo)
        {
            _cartsRepo = cartsRepo;
        }

        public void AddCart(CartViewModel data, string email)
        {
            Cart c = new Cart();
     
            c.quantity = 0;
            c.email = email;
            c.productId = data.Id;

            _cartsRepo.AddCart(c);
        }

        public IQueryable<CartViewModel> GetCart()
        {
            throw new NotImplementedException();
        }
    }
}
