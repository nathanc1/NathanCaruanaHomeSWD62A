using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICartsService
    {
        void AddCart(Guid id,string email,int quantity);
        IQueryable<CartViewModel> GetCart(CartViewModel data, string email);
        CartViewModel GetCarts(Guid id, string name);

        void UpdateQtyInCart(string email, Guid ProductId, int qty);
    }
}
