using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace book.Controllers
{
    public class AdminController : Controller
    {
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
        public ActionResult Login(Admin admin)
        {
            if (admin.TaiKhoan == "sonnx" && admin.MatKhau == "a")
            {
                Session["username"] = "sonnx";
                return Redirect("/HoaDon/List");

            }
            ViewBag.confirm = "fail";
            return RedirectToAction("Login"); 
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