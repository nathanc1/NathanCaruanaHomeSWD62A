using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrderDetailsService
    {
        void AddOrderDetails(OrderDetailViewModel od);

        OrderDetailViewModel GetOrder(Guid id);

        IQueryable<OrderDetailViewModel> GetProdsCart(Guid id, string email);

    }
}
