using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            ViewBag.username = "sonnx";
            List<HoaDon> list = new List<HoaDon>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new HoaDon(i,  i+1111,"Ma giam gia "+i,i*1000,DateTime.Now, DateTime.Now));
            }
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.username = "sonnx";
            int i = id;
            HoaDon hoaDon = new HoaDon(i, i + 1111, "Ma giam gia " + i, i * 1000
                , DateTime.Now, DateTime.Now);
            return View(hoaDon);
        }

        [HttpPost]
        public ActionResult Edit(HoaDon HoaDon)
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
        public ActionResult Create(HoaDon HoaDon)
        {
            //Save to database
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            ViewBag.username = "sonnx";

            int i = id;
            HoaDon hoaDon = new HoaDon(i, i + 1111, "Ma giam gia " + i, i * 1000
                , DateTime.Now, DateTime.Now);
            return View(hoaDon);
        }


        public ActionResult Delete(int id)
        {
            ViewBag.username = "sonnx";

            int i = id;
            HoaDon hoaDon = new HoaDon(i, i + 1111, "Ma giam gia " + i, i * 1000
                , DateTime.Now, DateTime.Now);
            return View(hoaDon);
        }

        [HttpPost]
        public ActionResult Delete(HoaDon hoaDon)
        {
            //Delete to database
            return RedirectToAction("List");
        }
    }
}