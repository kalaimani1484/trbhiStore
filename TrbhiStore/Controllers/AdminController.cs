using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrbhiStore.Models.DB;
using TrbhiStore.Models;

namespace TrbhiStore.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: Admin
      
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View("Admin");
        }

      
        [HttpGet]
        public ActionResult Index()
        {
            var products = db.Products.Select(x => new ProductModel() {
                Id = x.ProductId,
                ProductName = x.ProductName,
                Price = x.Price,
                availableQuantity = x.availableQuantity
            });
            return View(products);
        }

      
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ProductModel product)
        {
            Products prods = new Products()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                availableQuantity = product.availableQuantity
            };

            // TODO: save image, get url and assign to url field

            db.Products.Add(prods);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var prod = db.Products.Where(x => x.ProductId == Id).Select(s => new ProductModel
            {
                Id = s.ProductId,
                ProductName = s.ProductName,
                Price = s.Price,
                availableQuantity = s.availableQuantity
            }).First();
            return View(prod);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel product)
        {
            Products prod = new Products
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                availableQuantity = product.availableQuantity
            };
            db.Entry(prod).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}