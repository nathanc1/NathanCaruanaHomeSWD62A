﻿using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IOrderDetailsRepository
    {
        void AddOrderDetails(OrderDetails od);

        IQueryable<OrderDetails> GetOrder(Guid id, string email);
        IQueryable <OrderDetails>GetProdsCart(Guid id, string email);

    }
}
