using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_BookStore1.Controllers
{
    public class BookStoreController : Controller
    {
        // GET: BookStore
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult SachBanChay()
        {
            return View();
        }
        public ActionResult TieuThuyet()
        {
            return View();
        }

    }
}