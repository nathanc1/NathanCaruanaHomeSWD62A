using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ICartsRepository
    {
        void AddCart(Cart c);
        IQueryable<Cart> GetCarts();

        void UpdateCart(Cart cart);

        Cart GetCart(Guid id,string email);
    }
}
