using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrbhiStore.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}