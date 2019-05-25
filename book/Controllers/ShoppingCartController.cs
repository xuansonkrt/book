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
<<<<<<< HEAD
           
           // int idBook = Int32.Parse(index);
            MyDBContext db = new MyDBContext();
            Book book = db.Books.Find(id);
            int amount = 1;
            int idAcc = Convert.ToInt16(Session["id"]);
            // kiem tra xem da login chua
            if (idAcc != 0)// da login 
            {
                CartUserDAO cartUser = new CartUserDAO();
                int idcart = cartUser.getID(idAcc);// lay gia id cart của ac
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
                    int idcart1 = cartUser.getID(idAcc);
                    CartDetail cartDetail = new CartDetail();
                    cartDetail.ID_Book = id;
                    cartDetail.ID_Cart = idcart1;
                    db.CartDetails.Add(cartDetail);
                    db.SaveChanges();

                }
                else  // co go hang
                {
                    
                    CartUserDAO userDAO = new CartUserDAO();
                    int? q = cartUser.GetQuanity(id, idcart);
                    if (q == -1)// cuon sach chua co trong gio hang
                    {
                        CartDetail cartDetail = new CartDetail();
                        cartDetail.ID_Book = id;
                        cartDetail.ID_Cart = idcart;
                        cartDetail.Quantity = 1;
                        db.CartDetails.Add(cartDetail);
                        db.SaveChanges();
                    }
                    else
                    {
                        int quanity  = (int) q + 1;
                        
                        CartDetail cartDetail = db.CartDetails.Find(id, idcart);
                        cartDetail.Quantity = quanity;
                        db.SaveChanges();
                    }
                    
                }
                // Get total 
                CartUserDAO cartUserDAO = new CartUserDAO();
                Session["cartAmount"] = cartUserDAO.GetTotal(idcart);
=======
             
            if(Session["username"] != null)
            {

            }
            int amount = 1;
            
            cart= (ShoppingCart)Session["cart"];

            if (cart == null)
            {
                cart= new ShoppingCart();
>>>>>>> 6f53dc05fdb21f04bdaa42727a8221b9111d7308
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
            int idAcc = Convert.ToInt16(Session["id"]);

            if (idAcc != 0)
            {
                CartUserDAO cartUser = new CartUserDAO();
                int idcart = cartUser.getID(idAcc);

                MyDBContext db = new MyDBContext();
                CartDetail cartD = new CartDetail();
                cartD = db.CartDetails.Find(id, idcart);
                db.CartDetails.Remove(cartD);
                db.SaveChanges();
                
            }
            else
            {
                ShoppingCart cart = (ShoppingCart)Session["cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart();
                }
                cart.RemoveItem(id);
                Session["cart"] = cart;
            }
            
            return Redirect(Request.UrlReferrer.ToString());
        }

        public JsonResult ChangeAmount(int id, int amount)
        {
            int idAcc = Convert.ToInt16(Session["id"]);
            if (idAcc !=0)
            {
                MyDBContext db = new MyDBContext();

                CartUserDAO cartUser = new CartUserDAO();
                int idcart = cartUser.getID(idAcc);
                CartDetail cartDetail = new CartDetail();
                cartDetail = db.CartDetails.Find(id, idcart);
                if( amount > 0)
                {
<<<<<<< HEAD
                    cartDetail.Quantity = amount;
                    db.SaveChanges();
                }
                else
                {
                    db.CartDetails.Remove(cartDetail);
                    db.SaveChanges();
                }
            }
            else
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
            }
           
=======
                    ret = -1
                }, JsonRequestBehavior.AllowGet);
            }
            cart.UpdateAmount(id,amount);
            Session["cart"] = cart;
>>>>>>> 6f53dc05fdb21f04bdaa42727a8221b9111d7308
            return Json(new
            {
                ret=1
            },JsonRequestBehavior.AllowGet);
        }
    }
}