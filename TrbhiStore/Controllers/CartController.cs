using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrbhiStore.Models.DB;
using TrbhiStore.Models;
using System.Web.Mvc;

namespace TrbhiStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        StoreEntities db = new StoreEntities();
        // GET: Cart
        public ActionResult Index()
        {
            var items = db.Cart.Where(x => x.UserName == User.Identity.Name).Select(s => new CartModel
            {
                Id = s.CartId,
                ProductID = s.ProductId,
                Quantity = s.Quantity,
                Price = s.Price,
                UserName = s.UserName,
                ProductName = s.Products.ProductName,
                UnitPrice = s.Products.Price
            }
            ).ToList();
            return View(items);
        }
        [HttpPost]
        [ActionName("Orders")]
        public ActionResult PlaceOrder()
        {
            var items = db.Cart.Where(x => x.UserName == User.Identity.Name).ToList<Cart>();

            Orders ord = new Orders
            {
                UserName = User.Identity.Name,
                Price = items.Sum(x => x.Price),
                Status = "Pending"
            };

            db.Entry(ord).State = System.Data.Entity.EntityState.Added;

            foreach(var dtls in items)
            {
                OrderDetails ordtls = new OrderDetails
                {
                    OrderId = ord.OrderId,
                    ProductId = dtls.ProductId,
                    Quantity = dtls.Quantity,
                    Status = "Pending"
                };
                db.Entry(ordtls).State = System.Data.Entity.EntityState.Added;
            }

            db.Cart.RemoveRange(db.Cart.Where(x => x.UserName == User.Identity.Name));
            db.SaveChanges();

            return View("Confirmation");
        }
    }
}