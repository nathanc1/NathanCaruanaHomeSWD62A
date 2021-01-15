﻿using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICartsService
    {
        void AddCart(CartViewModel data, string email);
        IQueryable<CartViewModel> GetCart(CartViewModel data, string email);
        CartViewModel GetProduct(Guid id, string name);
    }
}
