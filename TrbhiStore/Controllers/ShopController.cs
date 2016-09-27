using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrbhiStore.Models.DB;
using TrbhiStore.Models;

namespace TrbhiStore.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        StoreEntities db = new StoreEntities();
        // GET: Shop
        public ActionResult Index()
        {
            var prods = db.Products.Select(x => 
            new ProductModel {
                Id = x.ProductId,
                ProductName = x.ProductName,
                Price = x.Price,
                availableQuantity = x.availableQuantity
            }).ToList();
            ViewBag.items = db.Cart.Where(x => x.UserName == User.Identity.Name).Select(p => p.Quantity).DefaultIfEmpty(0).Sum();
            ViewBag.total = db.Cart.Where(x => x.UserName == User.Identity.Name).Select(p => p.Price).DefaultIfEmpty(0).Sum();
            return View(prods);
        }

        [HttpPost]
        public ActionResult AddCart(int Id)
        {
            //var Id = 1;
            var prod = db.Products.Where(x => x.ProductId == Id).Select(x => x).First();

            var crt = db.Cart.Where(x => x.UserName == User.Identity.Name && x.ProductId == Id).Select(s =>
               new CartModel
               {
                   Id = s.CartId,
                   Price = s.Price,
                   ProductID = s.ProductId,
                   Quantity = s.Quantity,
                   UserName = s.UserName
               }
                ).FirstOrDefault();

            if (crt == null) {
                Cart c = new Cart()
                {
                    ProductId = Id,
                    Quantity = 1,
                    UserName = User.Identity.Name,
                    Price = prod.Price
                };
                db.Entry(c).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
            else
            {
                Cart c = new Cart()
                {
                    CartId = crt.Id,
                    ProductId = crt.ProductID,
                    Quantity = crt.Quantity + 1,
                    Price = crt.Price + prod.Price,
                    UserName = crt.UserName
                    
                };
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            var total = db.Cart.Where(x => x.UserName == User.Identity.Name).Select(p => p.Price).DefaultIfEmpty(0).Sum();
            var count = db.Cart.Where(x => x.UserName == User.Identity.Name).Select(p => p.Quantity).DefaultIfEmpty(0).Sum();

            var result = new
            {
                count = count,
                total = total
            };

            return Json(result);
        }
    }
}