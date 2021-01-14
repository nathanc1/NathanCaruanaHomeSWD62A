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
            c.productId = data.Id;
            c.quantity = 1;
            c.email = email;
            _cartsRepo.AddCart(c);
        }

        public IQueryable<CartViewModel> GetCart(CartViewModel data, string email)
        {
            var list = from c in _cartsRepo.GetCart()
                       select new CartViewModel()
                       {
                           Id = c.Id,
                           email = c.email,
                           quantity = c.quantity,
                           Product = new ProductViewModel() {Id = c.Product.Id, Name = c.Product.Name}
                       };
            return list;
        }

        public CartViewModel GetProduct(Guid id)
        {
            CartViewModel myViewModel = new CartViewModel();
            var productFromDb = _cartsRepo.GetProduct(id);

            myViewModel.Product.Id = productFromDb.Product.Id;
            myViewModel.Product.Name = productFromDb.Product.Name;
            return myViewModel;
        }
    }
}
