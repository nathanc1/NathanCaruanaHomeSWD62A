using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int quantity { get; set; }

        [ForeignKey("Product")]
        public int productId { get; set; }
    }
}
