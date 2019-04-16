using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace book.Controllers
{
    public class TheLoaiController : Controller
    {
        // GET: TheLoai
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            ViewBag.username = "sonx";
            ViewBag.avatar = "~/Content/images/IMG_9405-3.jpg";
            List<TheLoai> list = new List<TheLoai>();
            for(int i=0; i<10; i++)
            {
                list.Add(new TheLoai(i, "The loai " + i));
            }
            return View(list);
        }


        public ActionResult Create()
        {
            ViewBag.username = "sonx";
            return View();
        }
        [HttpPost]
        public ActionResult Create(TheLoai _theLoai)
        {
            //save to db
            return RedirectToAction("List");
        }
        // Sua the loai duoc chon
        public ActionResult Edit(int id)
        {
            ViewBag.username = "sonx";
            TheLoai theLoai = new TheLoai(id, " the loai 123");
            return View(theLoai);
        }
        [HttpPost]
        public ActionResult Edit(TheLoai theLoai)
        {
            //save to db
            return RedirectToAction("List");
        }
        // chi tiet the loai duoc chon
        public ActionResult Details(int id)
        {
            TheLoai the = new TheLoai(id, "name");
            return View(the);
        }
        [HttpPost]
        public ActionResult Details()
        {

            return RedirectToAction("List");
        }
        // xoa the loai duoc chon   
        public ActionResult Delete(int id)
        {
            TheLoai theLoai = new TheLoai(id, " the loai ");
            return View(theLoai);

        }
        [HttpPost]
        public ActionResult Delete(TheLoai theLoai)
        {
            return RedirectToAction("List");
        }
    }
}