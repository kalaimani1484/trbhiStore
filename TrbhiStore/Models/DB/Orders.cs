using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrbhiStore.Models.DB
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}