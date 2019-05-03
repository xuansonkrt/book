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
            cart= (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart= new ShoppingCart();
            }
            MyDBContext db= new MyDBContext();
            Book book = db.Books.Find(id);
            if (book != null)
            {
                cart.InsertItem(book.ID,book.Name,(double)book.Price);
            }
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Cart()
        {

            return View();
        }
    }
}