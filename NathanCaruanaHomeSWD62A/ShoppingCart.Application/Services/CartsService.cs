using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Model;
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
        private IProductsRepository _productsRepo;
        private IMapper _mapper;
        public CartsService(ICartsRepository cartsRepo, IProductsRepository productsRepo, IMapper mapper)
        {
            _cartsRepo = cartsRepo;
            _productsRepo = productsRepo;
            _mapper = mapper;
        }
        public void AddCart(Guid productId ,string email, int qty)
        {
            Cart cart = _cartsRepo.GetCart(productId, email);

            if (cart == null)
            {
                qty = 1;

                _cartsRepo.AddCart(new Cart()
                {
                    email = email,
                    productId = productId,
                    quantity = qty

                });
            }
            else{
                UpdateQtyInCart(email, productId, qty);
            }
        }
        public IQueryable<CartViewModel> GetCart(CartViewModel data, string email)
        {
            var list = from c in _cartsRepo.GetCarts()
                       select new CartViewModel()
                       {
                           Id = c.Id,
                           email = c.email,
                           quantity = c.quantity,
                           Product = new ProductViewModel() {Id = c.Product.Id, Name = c.Product.Name}
                       };
            return list;
          
        }
        
        public CartViewModel GetCarts(Guid id, string email)
        {
            //    Cart cart = _cartsRepo.GetProduct(id,email);

            CartViewModel myViewModel = new CartViewModel();
            
            var productFromDb = _cartsRepo.GetCart(id, email);

            myViewModel.Product.Id = id;
            return myViewModel;
        }
        

        public void UpdateQtyInCart(string email, Guid ProductId, int qty)
        {
            //1. fetch the row from the carts table that belong to the email

            
            Cart originalCart = _cartsRepo.GetCart(ProductId, email);

            originalCart.quantity += qty+1;

            _cartsRepo.UpdateCart(originalCart);
        }
    }
}
