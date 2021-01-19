using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class CartViewModel
    {
        public Guid Id { get; set; }

        public int quantity { get; set; }

        public Guid productId { get; set; }

        public string email { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
