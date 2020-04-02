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
    }
}