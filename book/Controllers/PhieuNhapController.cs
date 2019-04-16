using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class PhieuNhapController : Controller
    {
        // GET: PhieuNhap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            ViewBag.username = "sonnx";
            List<PhieuNhap> list = new List<PhieuNhap>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new PhieuNhap(i,DateTime.Now,i+1111));
            }
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.username = "sonnx";
            int i = id;
            PhieuNhap PhieuNhap = new PhieuNhap(i, DateTime.Now, i + 1111);
            return View(PhieuNhap);
        }

        [HttpPost]
        public ActionResult Edit(PhieuNhap phieuNhap)
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
        public ActionResult Create(PhieuNhap PhieuNhap)
        {
            //Save to database
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            ViewBag.username = "sonnx";

            int i = id;
            PhieuNhap PhieuNhap = new PhieuNhap(i, DateTime.Now, i + 1111);
            return View(PhieuNhap);
        }


        public ActionResult Delete(int id)
        {
            ViewBag.username = "sonnx";
            int i = id;
            PhieuNhap PhieuNhap = new PhieuNhap(i, DateTime.Now, i + 1111);
            return View(PhieuNhap);
        }

        [HttpPost]
        public ActionResult Delete(PhieuNhap PhieuNhap)
        {
            //Delete to database
            return RedirectToAction("List");
        }
    }
}