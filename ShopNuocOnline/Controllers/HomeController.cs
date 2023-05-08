using ShopNuocOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocOnline.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
           
        {
            var listProduct = db.Products.ToList();
            return View(listProduct);
        }

        public ActionResult ThucDon()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TinTuc()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}