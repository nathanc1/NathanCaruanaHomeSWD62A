﻿using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository _productsRepo;
        public ProductsService(IProductsRepository productsRepo)
        {
            _productsRepo = productsRepo;
        }

        public ProductViewModel GetProduct(Guid id)
        {
            ProductViewModel myViewModel = new ProductViewModel();
            var productFromDb = _productsRepo.GetProduct(id);

            myViewModel.Description = productFromDb.Description;
            myViewModel.Id = productFromDb.Id;
            myViewModel.ImageUrl = productFromDb.ImageUrl;
            myViewModel.Name = productFromDb.Name;
            myViewModel.Price = productFromDb.Price;
            myViewModel.Category = new CategoryViewModel();
            myViewModel.Category.Id = productFromDb.Category.Id;
            myViewModel.Category.Name = productFromDb.Category.Name;
            return myViewModel;
        }


        public IQueryable<ProductViewModel> GetProducts()
        {
            var list = from p in _productsRepo.GetProducts()
                       select new ProductViewModel()
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Price = p.Price,
                           Description = p.Description,
                           ImageUrl = p.ImageUrl,
                           Category = new CategoryViewModel() { Id = p.Category.Id, Name = p.Category.Name}

                       };
            return list;
        }
        public void AddProduct(ProductViewModel data)
        {
            // ProductViewModel ======> Product
            Product p = new Product();
            p.Description = data.Description;
            p.ImageUrl = data.ImageUrl;
            p.Name = data.Name;
            p.Price = data.Price;
            p.CategoryId = data.Category.Id;


            _productsRepo.AddProduct(p);
        }

        public void DeleteProduct(Guid id)
        {
            if (_productsRepo.GetProduct(id) != null)
            {
                _productsRepo.DeleteProduct(id);
            }
        }

    }
}
