using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopGunLab_Practice3.Models;

namespace TopGunLab_Practice3.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            if (Session.Count == 0)
            {

                Session["Products"] = new List<Product>();

            }

            var products = Session["Products"] as List<Product>;
            return View(products);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {

            return View();

        }
        [HttpPost]
        public ActionResult NewProduct(Product product)
        {

            return RedirectToAction("Index");
        }

        public ActionResult ProductSearch(string param)
        {
            var products = Session["Products"] as List<Product>;
            if (!string.IsNullOrEmpty(param))
            {
                Session["Param"] = param;
                products = products.Where(p => p.Name.ToLower().StartsWith(param.ToLower())).ToList();
            }
            return PartialView("_Products", products);



        }
        public ActionResult DeleteProduct(int id)
        {

            var products = Session["Products"] as List<Product>;
            var removedProduct = products.FirstOrDefault(p => p.ProductId == id);
            if (removedProduct != null)
            {
                products.Remove(removedProduct);
            }
            return View(products);

        }
    }
}