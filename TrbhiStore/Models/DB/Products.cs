using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TrbhiStore.Models.DB
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int availableQuantity { get; set; }

        public string ImageURL { get; set; }

        public ICollection<Cart> Cart { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}