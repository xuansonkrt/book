using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.DAO;
using book.Models.Entities;
using book.Models.ViewModels;
using PagedList;

namespace book.Controllers
{
    public class InvoiceController : Controller
    {
        MyDBContext db = new MyDBContext();
        InvoiceDAO dao = new InvoiceDAO();
        // GET: Invoice
        public ActionResult Index(int? page = 1, int pageSize = 10)
        {
            if (!(bool)Session["isAdmin"])
            {
                return Redirect("/Admin/Login");
            }
            int pageNumber = page ?? 1;

            string _invoiceStatusID = Request.QueryString["InvoiceStatusID"];
            string _keyWord = Request.QueryString["keyWord"];

            int invoiceStatusId = 0;
            string keyWord = "";
            if (_invoiceStatusID!=null)
            {
                invoiceStatusId= Int32.Parse(_invoiceStatusID);
            }
            if (_keyWord != null)
            {
                keyWord = _keyWord;
            }
            InvoiceStatusDAO invoiceStatusDao = new InvoiceStatusDAO();
            List<InvoiceStatu> invoiceStatus = invoiceStatusDao.GetAll();
            SelectList statusList = new SelectList(invoiceStatus, "ID", "Name");
            ViewBag.InvoiceStatusList = statusList;
            ViewBag.InvoiceStatusList2 = invoiceStatus;
            // var list = dao.GetAll();
            var list = dao.GetAll2(invoiceStatusId, keyWord).ToPagedList(pageNumber, pageSize);
            //var list = (from l in db.Categories
            //            select l).OrderBy(x => x.Name);
            return View(list);
        }

        public JsonResult ChangeStatus(Invoice _invoice)
        {
            InvoiceDAO dao = new InvoiceDAO();
            int ret = dao.Update(_invoice);
            return Json(new
            {
                ret
            },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(string id)
        {
            if (!(bool)Session["isAdmin"])
            {
                return Redirect("/Admin/Login");
            }
            InvoiceDAO dao = new InvoiceDAO();
            Invoice invoice = dao.GetByID(Int32.Parse(id));
            List<Item> list = new List<Item>();
            foreach (var item in invoice.InvoiceDetails)
            {
                Item temp = new Item();
                temp.id = item.ID;
                temp.amount =(int) item.Quantity;
                temp.price = (double)item.Price;
                temp.name = item.Book.Name;
                temp.mainImage = item.Book.MainImage;
                list.Add(temp);
            }

           
            var vm = new InvoiceDetailVM
            {
                invoice = invoice,
                list = list
            };
            return View(vm);
        }

        public ActionResult Print(string id)
        {
            if (!(bool)Session["isAdmin"])
            {
                return Redirect("/Admin/Login");
            }
            InvoiceDAO dao = new InvoiceDAO();
            Invoice invoice = dao.GetByID(Int32.Parse(id));
            List<Item> list = new List<Item>();
            foreach (var item in invoice.InvoiceDetails)
            {
                Item temp = new Item();
                temp.id = item.ID;
                temp.amount = (int)item.Quantity;
                temp.price = (double)item.Price;
                temp.name = item.Book.Name;
                temp.mainImage = item.Book.MainImage;
                list.Add(temp);
            }
            
            var vm = new InvoiceDetailVM
            {
                invoice = invoice,
                list = list
            };
            return View("~/Views/Invoice/print.cshtml",vm);
        }
    }
}