using ShopNuocOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocOnline.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/User
        public ActionResult Index()
        {
            var users = db.AspNetUsers.ToList();
            return View(users);
        }

        public ActionResult Delete(string id)
        {
            var user = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(user);
            db.SaveChanges();
            return Redirect("/Admin/User");
        }
    }
}