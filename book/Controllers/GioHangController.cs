using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class GioHangController : Controller
    {
        // GET: PhieuNhap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<GioHang> list = new List<GioHang>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new GioHang(i, DateTime.Now, i));
            }
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            GioHang gioHang = new GioHang(id, DateTime.Now, 1);
            return View(gioHang);
        }

        [HttpPost]
        public ActionResult Edit(GioHang phieuNhap)
        {
            //Save to database
            return RedirectToAction("List");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GioHang phieuNhap)
        {
            //Save to database
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {

            GioHang phieuNhap = new GioHang(id, DateTime.Now, 1);
            return View(phieuNhap);
        }


        public ActionResult Delete(int id)
        {
            GioHang phieuNhap = new GioHang(id, DateTime.Now, 1);
            return View(phieuNhap);
        }


        [HttpPost]
        public ActionResult Delete(GioHang phieuNhap)
        {
            //Delete to database
            return RedirectToAction("List");
        }
    }
}