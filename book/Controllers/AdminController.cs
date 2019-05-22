using book.DAO;
using book.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace book.Controllers
{
    public class AdminController : Controller
    {
        AdminDAO dao = new AdminDAO();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            //  ViewBag.confirm = "begin";
            return View();
        }
        [HttpPost]
        public JsonResult Login(Account _admin)
        {
            
            int ret = -1;
            Account admin = dao.GetAdmin(_admin.UserName, _admin.Password);
            if (admin!=null)
            {
                ret = 1;
                Session["username"] = admin.Name;
                Session["avatar"] = admin.Avatar;
                ret = 1;
            }
            return Json(new
            {
                ret //ok
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult Management()
        {
            ViewBag.username = "sonnx";
            return View();
        }
    }
}