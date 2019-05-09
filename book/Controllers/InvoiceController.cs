using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.DAO;
using book.Models.Entities;
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
            if ((Session["username"] == null))
            {
                return Redirect("/Admin/Login");
            }
            int pageNumber = page ?? 1;

            InvoiceStatusDAO invoiceStatusDao = new InvoiceStatusDAO();
            List<InvoiceStatu> invoiceStatus = invoiceStatusDao.GetAll();
            SelectList statusList = new SelectList(invoiceStatus, "ID", "Name");
            ViewBag.InvoiceStatusList = statusList;
            ViewBag.InvoiceStatusList2 = invoiceStatus;
            // var list = dao.GetAll();
            var list = dao.GetAll2().ToPagedList(pageNumber, pageSize);
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

    }
}