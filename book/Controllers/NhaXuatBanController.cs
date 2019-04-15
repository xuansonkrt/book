using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: NhaXuatBan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<NhaXuatBan> list = new List<NhaXuatBan>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new NhaXuatBan(i, "name "+ i));
            }
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            NhaXuatBan nhaXuatBan = new NhaXuatBan(id, "name");
            return View(nhaXuatBan);
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
        public ActionResult Create(NhaXuatBan nhaXuatBan)
        {
            //Save to database
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {

            NhaXuatBan nhaXuatBan = new NhaXuatBan(id, "name");
            return View(nhaXuatBan);
        }


        public ActionResult Delete(int id)
        {
            NhaXuatBan nhaXuatBan = new NhaXuatBan(id, "name");
            return View(nhaXuatBan);
        }

        [HttpPost]
        public ActionResult Delete(NhaXuatBan nhaXuatBan)
        {
            //Delete to database
            return RedirectToAction("List");
        }
    }
}