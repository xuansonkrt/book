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
            List<Item> lst = new List<Item>();
            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = categoryList;

            List<Publisher> publisherList = db.Publishers.ToList();
            ViewBag.PublisherList = publisherList;
            // kiem tra xem da login chua 
            int amount = 1;
            int idAcc = Convert.ToInt16(Session["id"]);
            if( idAcc != 0)// da dk ddawng nhap 
            {
                //lay id gio hang 
                CartUserDAO cartUser = new CartUserDAO();
                int idcart = cartUser.getID(idAcc);
                // lay chi tiet gio hang 
                var sql = " exec bookcart " + idcart;
                lst = (from b in db.Books
                           join a in db.CartDetails on b.ID equals a.ID_Book
                           join c in db.Carts.Where(c => c.ID == idAcc) on a.ID_Cart equals c.ID
                           select new Item
                           {
                               id = b.ID,
                               name = b.Name,
                               price =(decimal)( b.Price),
                               amount = (int)(b.Quantity),
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
            //
            
            return View(lst);
        }

        public ActionResult Checkout()
        {
            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = categoryList;

            List<Publisher> publisherList = db.Publishers.ToList();
            ViewBag.PublisherList = publisherList;

            return View();
        }


        public JsonResult Checkout2(Invoice invoice)
        {
            MyDBContext db = new MyDBContext();

            int amount = 1,ret;
            int idAcc = Convert.ToInt16(Session["id"]);
            // neu co dang nhap
            if (idAcc != 0)
            {

            }
            else
            {
                ShoppingCart cart = (ShoppingCart)Session["cart"];
                if (cart == null)
                {
                    return Json(new
                    {
                        ret = -1
                    }, JsonRequestBehavior.AllowGet);
                }

                Invoice obj = new Invoice();
                obj.Email = invoice.Email;
                obj.Address = invoice.Address;
                obj.PhoneNumber = invoice.PhoneNumber;
                obj.CustomerName = invoice.CustomerName;
                obj.ID_Account = Convert.ToInt16(Session["id"]);
                obj.Price= (decimal?)cart.GetTotalMoney();
                obj.ID_InvoiceStatus = 1;
                obj.OrderDate = DateTime.Now;
                obj.ID_Account = null;
                InvoiceDAO invoiceDAO = new InvoiceDAO();

                ret = invoiceDAO.Insert(obj);
                if (ret > 0)
                {
                    BookDAO bookDao = new BookDAO();
                    InvoiceDetailDAO invoiceDetailDao = new InvoiceDetailDAO();
                    foreach (var item in cart.lst)
                    {
                        InvoiceDetail invoiceDetail = new InvoiceDetail();
                        invoiceDetail.ID_Book = item.id;
                        invoiceDetail.ID_Invoice = obj.ID;
                        invoiceDetail.Price = (decimal?)item.price;
                        invoiceDetail.Quantity = item.amount;
                        ret = invoiceDetailDao.Insert(invoiceDetail);
                        if (ret < 0)
                        {
                            break;
                        }
                    }
                }

                if (ret > 0)
                {
                    Session["cartAmount"] = 0;
                    Session["cart"] = null;
                }
                return Json(new
                {
                    ret
                }, JsonRequestBehavior.AllowGet);

            }





            return Json(new
            {
                ret=-1
            }, JsonRequestBehavior.AllowGet);
        }
    }
}