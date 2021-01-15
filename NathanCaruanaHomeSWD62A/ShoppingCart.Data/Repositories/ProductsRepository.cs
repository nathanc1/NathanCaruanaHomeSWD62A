﻿using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Data.Repositories
{
    public class ProductsRepository : IProductsRepository    
    {
        private ShoppingCartDBContext _context;
        public ProductsRepository(ShoppingCartDBContext context)
        {
            _context = context;
        }
        public void AddProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            var myProduct = GetProduct(id);
            _context.Products.Remove(myProduct);
            _context.SaveChanges();
        }

        public Product GetProduct(Guid id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);
            //if it does not find a product with a matching id... it will return null!!
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }
    }
}
