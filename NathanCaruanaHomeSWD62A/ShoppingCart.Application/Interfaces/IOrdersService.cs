using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrdersService
    {
        //  void Checkout(List<Product>productsInCart);
        void AddOrder(OrderViewModel o, string email);

    
    }
}
