using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrbhiStore.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int availableQuantity { get; set; }
        public HttpPostedFileBase ProductImage { get; set; }
    }
}