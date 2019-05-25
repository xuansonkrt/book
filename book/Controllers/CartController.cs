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
            ShoppingCart cart = (ShoppingCart) Session["cart"];
            if (cart == null)
            {
<<<<<<< HEAD
                //lay id gio hang 
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
               
=======
                cart= new ShoppingCart();
>>>>>>> 6f53dc05fdb21f04bdaa42727a8221b9111d7308
            }
            List<Item> lst = new List<Item>();
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

            int amount = 1;
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                return Json(new
                {
                    ret = -1
                }, JsonRequestBehavior.AllowGet);
            }

            //    CustomerDAO customerDao = new CustomerDAO();
            //    Customer obj = new Customer();
            //    obj.Email = customer.Email;
            //    obj.Address = customer.Address;
            //    obj.Telephone = customer.Telephone;
            //    obj.Name = customer.Name;

            //    db.Customers.Add(customer);
            //    int ret = customerDao.Insert(obj);
            //    if (ret > 0)
            //    {
            //        InvoiceDAO invoiceDao = new InvoiceDAO();
            //        Invoice invoice = new Invoice();
            //        invoice.ID_Custom = obj.ID;
            //        invoice.OrderDate = DateTime.Now;
            //        invoice.Price = (decimal?)cart.GetTotalMoney();
            //        ret = invoiceDao.Insert(invoice);
            //        if (ret > 0)
            //        {
            //            BookDAO bookDao = new BookDAO();
            //            InvoiceDetailDAO invoiceDetailDao = new InvoiceDetailDAO();
            //            foreach (var item in cart.lst)
            //            {
            //                InvoiceDetail invoiceDetail = new InvoiceDetail();
            //                invoiceDetail.ID_Book = item.id;
            //                invoiceDetail.ID_Invoice = invoice.ID;
            //                invoiceDetail.Price = (decimal?)item.price;
            //                invoiceDetail.Quantity = item.amount;
            //                ret = invoiceDetailDao.Insert(invoiceDetail);
            //                if (ret < 0)
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //    }

            //    if (ret > 0)
            //    {
            //        Session["cartAmount"] = 0;
            //        Session["cart"] = null;
            //    }

            return Json(new
            {
                ret=-1
            }, JsonRequestBehavior.AllowGet);
        }
    }
}