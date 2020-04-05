using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TopGunLab_Practice3.Models;
using TopGunLab_Practice3.Models.Third_part;

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

            
            if (!Regex.IsMatch(product.Name, "[A-Za-zА-Яа-я0-9\\.]+"))
            {
                ModelState.AddModelError(nameof(product.Name), "Product name is not valid");
            }
            if (product.Price < 0)
            {
                ModelState.AddModelError(nameof(product.Price), "Number  is not valid");
            }
            if (product.Count < 0)
            {
                ModelState.AddModelError(nameof(product.Count), "Number  is not valid");
            }
            if (DateTime.Compare(product.ExcpiryDate, DateTime.Now) < 0)
            {

                ModelState.AddModelError(nameof(product.ProductionDate), "Expire date is not valid! It cannot be earlier");
            }

            if (ModelState.IsValid)
            {
                var file = Request.Files[0];
                if (file.ContentLength > 0)
                {

                    var filename = file.FileName;
                    var path = Path.Combine(Server.MapPath("~/Content/Images/img"), filename);
                    file.SaveAs(path);
                    product.Logo = filename;
                }

                var products = Session["Products"] as List<Product>;
                product.ProductId = IdBangerProduct.UpdateId(products);
                products.Add(product);

                Session["Products"] = products;
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
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
        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {

            var products = Session["Products"] as List<Product>;
            var removedProduct = products.FirstOrDefault(p => p.ProductId == id);
            if (removedProduct != null)
            {
                products.Remove(removedProduct);
            }
            Session["Products"] = products;
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult ProductEditor(int id)
        {
            Session["ProdId"] = id;
            var products = Session["Products"] as List<Product>;
            var currentProduct = products.FirstOrDefault(p => p.ProductId == id);
            if (currentProduct != null)
            {
                return View(currentProduct);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult ProductEditor(Product product)
        {
            var prodId = (int)Session["ProdId"];
            var products = Session["Products"] as List<Product>;
            var currentProduct = products.Find(p => p.ProductId == prodId);


            if (!Regex.IsMatch(product.Name, "[A-Za-zА-Яа-я0-9\\.]+"))
            {
                ModelState.AddModelError(nameof(product.Name), "Product name is not valid");
            }
            if (product.Price < 0)
            {
                ModelState.AddModelError(nameof(product.Price), "Number  is not valid");
            }
            if (product.Count < 0)
            {
                ModelState.AddModelError(nameof(product.Count), "Number  is not valid");
            }
            if (DateTime.Compare(product.ExcpiryDate, DateTime.Now) < 0)
            {

                ModelState.AddModelError(nameof(product.ProductionDate), "Expire date is not valid! It cannot be earlier");
            }
     
            if (ModelState.IsValid)
            {
                var file = Request.Files[0];
                if (file.ContentLength > 0)
                {

                    var filename = file.FileName;
                    var path = Path.Combine(Server.MapPath("~/Content/Images/img"), filename);
                    file.SaveAs(path);
                }

                if (prodId != 0)
                {
                    products.Remove(currentProduct);
                    var editedProduct = new Product()
                    {
                        ProductId = prodId,
                        Name = product.Name,
                        Price = product.Price,
                        Count = product.Count,
                        Description = product.Description,
                        ExcpiryDate = product.ExcpiryDate,
                        Logo = currentProduct?.Logo != null ? currentProduct.Logo : file?.FileName
                    };

                    products.Add(editedProduct);
                    Session["Products"] = products;
                }
                return RedirectToAction("Index");
            }
            else
            {
                product.Logo = currentProduct?.Logo;
                return View(product);
            }


        }
    }
}