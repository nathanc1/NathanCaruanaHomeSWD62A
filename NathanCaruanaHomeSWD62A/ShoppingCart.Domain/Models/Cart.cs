using ShoppingCart.Domain.Model;
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

        [Required]
        public string email { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        [ForeignKey("Product")]
        public Guid productId { get; set; }
    }
}
