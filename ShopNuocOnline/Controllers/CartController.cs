using ShopNuocOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocOnline.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1();
        // GET: Cart
        public ActionResult Index()
        {
            var carts = Session["Cart"] as List<Cart>;
            return View(carts);
        }

        public ActionResult AddItem(int id, int qty = 1)
        {
            var product = db.Products.Find(id);
            var carts = Session["Cart"] as List<Cart>;
            if (carts != null)
            {
                if (carts.Any(x => x.Id == id))
                {
                    foreach (var item in carts)
                    {
                        if (item.Id == id)
                        {
                            item.Qty += qty;
                            Session["Cart"] = carts;
                            return Redirect("/Cart");
                        }
                    }
                }
            }
            else
            {
                carts = new List<Cart>();
            }


            var itemCart = new Cart();
            itemCart.Id = id;
            itemCart.Price = product.ProductPrice;
            itemCart.Name = product.Name;
            itemCart.Image = product.Image;
            itemCart.Qty = qty;

            carts.Add(itemCart);
            Session["Cart"] = carts;
            return Redirect("/Cart");
        }

        public ActionResult RemoveItem(int id)
        {
            var carts = Session["Cart"] as List<Cart>;
            var item = carts.Find(x=>x.Id == id);
            carts.Remove(item);
            Session["Cart"] = carts;
            return Redirect("/Cart");
        }
    }
}