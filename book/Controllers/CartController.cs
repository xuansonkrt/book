using book.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using book.DAO;

namespace book.Controllers
{
    public class CartController : Controller
    {
        MyDBContext db = new MyDBContext();
        // GET: Cart
        public ActionResult Index()
        {
            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = categoryList;

            List<Publisher> publisherList = db.Publishers.ToList();
            ViewBag.PublisherList = publisherList;
           

            int idAcc = Convert.ToInt16(Session["id"]);
            List<Item> lst = new List<Item>();
            if (idAcc !=0)
            {
                CartUserDAO cartUser = new CartUserDAO();
                int idcart = cartUser.getID(idAcc);
                // lay chi tiet gio hang 
                var sql = " exec bookcart " + idcart;
                lst = (from b in db.Books
                           join a in db.CartDetails on b.ID equals a.ID_Book
                           join c in db.Carts.Where(c => c.ID == idcart) on a.ID_Cart equals c.ID
                           select new Item
                           {
                               id = b.ID,
                               name = b.Name,
                               price =(decimal)( b.Price),
                               amount = (int)(a.Quantity),
                               mainImage = b.MainImage
                           }).ToList<Item>();

            }
            else
            {
                ShoppingCart cart = (ShoppingCart)Session["cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart();
                }
                
                foreach (var item in cart.lst)
                {
                    Item temp = new Item();
                    temp.id = item.id;
                    temp.amount = item.amount;
                    temp.mainImage = item.mainImage;
                    temp.name = item.name;
                    temp.price = item.price;
                    lst.Add(temp);
                }
            }
           
            
            return View(lst);
        }

        public ActionResult Checkout()
        {
            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = categoryList;

            List<Publisher> publisherList = db.Publishers.ToList();
            ViewBag.PublisherList = publisherList;
            int idAcc = Convert.ToInt16(Session["id"]);
            if (idAcc != 0)
            {
                Account ac = new Account();
                ac = db.Accounts.Find(idAcc);
                ViewBag.HoTen = ac.Name;
                ViewBag.Email = ac.Email;
                ViewBag.Phone = ac.Telephone;
                ViewBag.address = ac.Address;
            }

                return View();
        }


        public JsonResult Checkout2(Invoice customer)
        {
            MyDBContext db = new MyDBContext();
            int idAcc = Convert.ToInt16(Session["id"]);
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            //if (cart == null)
            //{
            //    return Json(new
            //    {
            //        ret = -1
            //    }, JsonRequestBehavior.AllowGet);
            //}
            if (idAcc != 0)// neu dang nhap
            {
                InvoiceDAO invoiceDAO = new InvoiceDAO();
                // kiem tra xem co hoa don 
                int idInvoid = invoiceDAO.IDInvoice(idAcc);
                if ( idInvoid == -1)
                {
                    invoiceDAO.AddInvoice(idAcc);
                    db.SaveChanges();

                    // them vao invoiddetal
                    InvoiceDetailDAO invoice = new InvoiceDetailDAO();
                    invoice.Add(idAcc);
                    //
                    Session["cartAmount"] = 0;
                }
                //them invoid
                else
                {
                    // them vao invoiddetal
                    InvoiceDetailDAO invoice = new InvoiceDetailDAO();
                    invoice.Add(idAcc);

                    // xóa giỏ hàng ( xoa tat ca chi tiet gio hang)
                    CartUserDAO cartUser = new CartUserDAO();
                    int idcart = cartUser.getID(idAcc);
                    db.Carts.Remove(db.Carts.Find(idcart));
                    db.SaveChanges();
                    //

                    Session["cartAmount"] = 0;
                }



                return Json(new
                {
                    ret = 1
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                ret=1
            }, JsonRequestBehavior.AllowGet);
        }
    }
}