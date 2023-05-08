using ShopNuocOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocOnline.Controllers
{
    public class DetailsController : Controller
    {
        Model1 db = new Model1();
        // GET: Details
        public ActionResult ChiTiet()
        {
            return View();
        }
        public ActionResult ChiTiet1(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }
        public ActionResult ChiTiet2()
        {
            return View();
        }
    }
}