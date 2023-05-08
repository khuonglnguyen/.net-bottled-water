using ShopNuocOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocOnline.Controllers
{
    public class WaterController : Controller
    {
        // GET: Water
        public ActionResult ListWater()
        {
            Model1 context = new Model1();
            var listWater = context.Products.ToList();
            return View(listWater);
        }
    }
}