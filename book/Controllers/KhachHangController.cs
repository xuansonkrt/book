using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            ViewBag.username = "sonnx";
            List<KhachHang> list = new List<KhachHang>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new KhachHang(i, "name " + i,"email "+i,"pw "+i
                    ,"SDT "+i, (i%2), DateTime.Now ));
            }
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.username = "sonnx";

            int i = id;
            KhachHang khachHang = new  KhachHang(i, "name " + i, "email " + i, "pw " + i
                    , "SDT " + i, (i % 2), DateTime.Now);
            return View(khachHang);
        }

        [HttpPost]
        public ActionResult Edit(KhachHang khachHang)
        {
            //Save to database
            return RedirectToAction("List");
        }

        public ActionResult Create()
        {
            ViewBag.username = "sonnx";

            return View();
        }

        [HttpPost]
        public ActionResult Create(KhachHang khachHang)
        {
            //Save to database
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            ViewBag.username = "sonnx";

            int i = id;
            KhachHang khachHang = new KhachHang(i, "name " + i, "email " + i, "pw " + i
                    , "SDT " + i, (i % 2), DateTime.Now);
            return View(khachHang);
        }


        public ActionResult Delete(int id)
        {
            ViewBag.username = "sonnx";

            int i = id;
            KhachHang khachHang = new KhachHang(i, "name " + i, "email " + i, "pw " + i
                    , "SDT " + i, (i % 2), DateTime.Now);
            return View(khachHang);
        }

        [HttpPost]
        public ActionResult Delete(KhachHang khachHang)
        {
            //Delete to database
            return RedirectToAction("List");
        }
    }
}