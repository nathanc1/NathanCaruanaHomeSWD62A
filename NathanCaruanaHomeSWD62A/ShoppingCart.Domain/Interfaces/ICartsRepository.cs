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
        IQueryable<Cart> GetCart();

        Cart GetProduct(Guid id);
    }
}
