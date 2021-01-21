using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrderDetailsService
    {
        void AddOrderDetails(Guid ordid, Guid prodid, string email);

        IQueryable<OrderDetailViewModel> GetOrder(Guid id, string email);
        IQueryable<OrderDetailViewModel> GetProdsCart(Guid id, string email);

    }
}
