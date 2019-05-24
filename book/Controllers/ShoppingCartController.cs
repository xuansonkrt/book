using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.DAO;
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
           
           // int idBook = Int32.Parse(index);
            MyDBContext db = new MyDBContext();
            Book book = db.Books.Find(id);
            int amount = 1;
            int idAcc = Convert.ToInt16(Session["id"]);
            if (idAcc != 0)// kiem tra xem da login chua
            {
                CartUserDAO cartUser = new CartUserDAO();
                int idcart = cartUser.getID(idAcc);
                // kiem tra da co gio hang chua
                if (idcart == -1)// chua co gio hang
                {
                    // tao gio hang moi 
                    Cart cart = new Cart();
                    cart.ID_Account = idAcc;
                    cart.Date = DateTime.Now;
                    db.Carts.Add(cart);
                    db.SaveChanges();

                    // tao xong gio hang , them sach da chon vao gio hang
                    CartDetail cartDetail = new CartDetail();
                    cartDetail.ID_Book = id;
                    cartDetail.ID_Cart = cart.ID;

                }
                else  // co go hang
                {
                    CartDetail cartDetail = new CartDetail();
                    cartDetail.ID_Book = id;
                    cartDetail.ID_Cart = idcart;
                    CartUserDAO userDAO = new CartUserDAO();
                    int? q = cartUser.GetQuanity(id, idcart);
                    if (q == -1)// cuon sach chua co trong gio hang
                    {
                        cartDetail.Quantity = 1;
                    }
                    else
                    {
                        cartDetail.Quantity = cartDetail.Quantity + 1;
                    }
                    db.CartDetails.Add(cartDetail);
                    db.SaveChanges();
                }


            }
            else// chua login 
            {
                amount = 1;

                cart = (ShoppingCart)Session["cart"];

                if (cart == null)
                {
                    cart = new ShoppingCart();
                }

                if (book != null)
                {
                    cart.InsertItem(book.ID, book.Name, (decimal)book.Price, amount);
                }

                Session["cartAmount"] = cart.GetTotal();
                Session["cart"] = cart;
            }

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
                cart.InsertItem(book.ID, book.Name, (decimal)book.Price, amount);
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
                    ret = 1
                }, JsonRequestBehavior.AllowGet);
            }
            cart.UpdateAmount(id, amount);
            Session["cart"] = cart;
            return Json(new
            {
                ret = 1
            }, JsonRequestBehavior.AllowGet);
        }
    }
}