using ShopNuocOnline.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocOnline.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = db.Products.Where(x => x.IsActive).ToList();
            return View(products);
        }

        public ActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            if (image != null)
            {
                //Get file name
                var fileName = Path.GetFileName(image.FileName);
                //Get path
                var path = Path.Combine(Server.MapPath("~/Assets/images"), fileName);
                //Check exitst
                if (!System.IO.File.Exists(path))
                {
                    //Add image into folder
                    image.SaveAs(path);
                }

                product.Image = fileName;
            }

            var productUpdate = db.Products.Find(product.Id);
            productUpdate.Name = product.Name;
            productUpdate.ProductPrice = product.ProductPrice;
            productUpdate.Description = product.Description;
            productUpdate.Quantity = product.Quantity;
            if (image != null)
            {
                productUpdate.Image = "/Assets/images/" + product.Image;
            }

            db.SaveChanges();
            ViewBag.success = true;
            return View(productUpdate);
        }

        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            product.IsActive = false;
            db.SaveChanges();
            return Redirect("/Admin/Products");
        }
    }
}