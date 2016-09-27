using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrbhiStore.Models.DB
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public String UserName { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Products Products { get; set; }
    }
}