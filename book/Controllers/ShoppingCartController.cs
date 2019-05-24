using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.Models.Entities;

namespace book.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ShoppingCart cart;
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int id)
        {
             
            if(Session["username"] != null)
            {

            }
            int amount = 1;
            
            cart= (ShoppingCart)Session["cart"];

            if (cart == null)
            {
                cart= new ShoppingCart();
            }
            MyDBContext db= new MyDBContext();
            Book book = db.Books.Find(id);
            if (book != null)
            {
                cart.InsertItem(book.ID,book.Name,(double)book.Price,amount);
            }

            Session["cartAmount"] = cart.GetTotal();
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

   //     [HttpPost]
        public JsonResult Add2(int id, int amount)
        {
            //int amount = 1;
            cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            MyDBContext db = new MyDBContext();
            Book book = db.Books.Find(id);
            if (book != null)
            {
                cart.InsertItem(book.ID, book.Name, (double)book.Price, amount);
            }

            Session["cartAmount"] = cart.GetTotal();
            Session["cart"] = cart;
            return Json(new
            {
                ret = 1
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cart()
        {

            return View();
        }

        public ActionResult Remove(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            cart.RemoveItem(id);
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public JsonResult ChangeAmount(int id, int amount)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                return Json(new
                {
                    ret = -1
                }, JsonRequestBehavior.AllowGet);
            }
            cart.UpdateAmount(id,amount);
            Session["cart"] = cart;
            return Json(new
            {
                ret=1
            },JsonRequestBehavior.AllowGet);
        }
    }
}