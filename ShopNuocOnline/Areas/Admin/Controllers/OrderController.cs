using ShopNuocOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocOnline.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Order
        public ActionResult Index()
        {
            var orders = db.Orders.ToList();
            return View(orders);
        }

        public ActionResult Detail(int id)
        {
            var orderDetail = db.OrderDetails.Where(x => x.OrderId == id).ToList();
            ViewBag.Id = id;
            return View(orderDetail);
        }
    }
}