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
    public class WareHouseController : Controller
    {
        // GET: WareHouse
        public ActionResult Index(int? page = 1, int pageSize = 10)
        {
            if (!(bool)Session["isAdmin"])
            {
                return Redirect("/Admin/Login");
            }
            int pageNumber = page ?? 1;
            BookDAO dao = new BookDAO();
            List<Book> list = dao.GetAll3();
            var listBook = list.ToPagedList(pageNumber, pageSize);
            IPagedList<Book> pageBook = new StaticPagedList<Book>(listBook
                , pageNumber, pageSize, list.Count());
            return View(pageBook);
        }

        public ActionResult Import(int? page = 1, int pageSize = 10)
        {
            if (!(bool)Session["isAdmin"])
            {
                return Redirect("/Admin/Login");
            }
            int pageNumber = page ?? 1;
            List<Import> list = new List<Import>();
            ImportDAO dao = new ImportDAO();
            list = dao.GetAll();
            var listImport = list.ToPagedList(pageNumber, pageSize);
            IPagedList<Import> pageImport = new StaticPagedList<Import>(listImport
                , pageNumber, pageSize, list.Count());
            return View(pageImport);
        }


        public JsonResult Add(List<ItemImport> lst, string totalPrice)
        {
            AccountDAO accountDao = new AccountDAO();
            Account login = accountDao.GetOnlineSession(Session["acc"].ToString());
            if (login == null)
            {
                return Json(new
                {
                    ret=-1
                },JsonRequestBehavior.AllowGet);
            }
            if (lst == null)
            {
                return Json(new
                {
                    ret = -2
                }, JsonRequestBehavior.AllowGet);
            }
            ImportDAO dao = new ImportDAO();
            int ret = dao.Add(lst, login.ID, Decimal.Parse(totalPrice));
          
            return Json(new
            {
                ret
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(string id)
        {
            ImportDetailDAO dao = new ImportDetailDAO();
            List<ImportDetail> list = dao.GetList(Int32.Parse(id));
            List<ItemImport> lst = new List<ItemImport>();
            foreach (var item in list)
            {
                ItemImport obj = new ItemImport();
                obj.ID = item.ID;
                obj.Name = item.Book.Name;
                obj.Amount = (double)item.Amount;
                obj.Price = (decimal)item.Price;
                lst.Add(obj);
            }
            int ret = list == null ? -1 : 1;
            return Json(new
            {
                ret, lst
            }, JsonRequestBehavior.AllowGet);

        }
    }
}