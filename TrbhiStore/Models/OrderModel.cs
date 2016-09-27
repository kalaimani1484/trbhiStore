using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrbhiStore.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public List<OrderDetailsModel> OrderDetails { get; set; }
    }

    public class OrderDetailsModel
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}