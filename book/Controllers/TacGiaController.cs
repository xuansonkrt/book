using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagementSystem.Models;

namespace BookManagementSystem.Controllers
{
    public class TacGiaController : Controller
    {
        // GET: TacGia
        public ActionResult Index()
        {
            ViewBag.username = "sonnx";
            return View();
        }
        // tao list TacGia
        public ActionResult List()
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
            ViewBag.username = "sonnx";
            List<TacGia> list = new List<TacGia>();
            for (int i = 0; i <= 10; i++)
            {
                TacGia TacGia = new TacGia();
                TacGia.Id = i;
                TacGia.Name = " tac gia " + i;
                list.Add(TacGia);
            }
            return View(list);
        }
        //tao TacGia moi
        public ActionResult Create()
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
            ViewBag.username = "sonnx";
            return View();
        }
        [HttpPost]
        public ActionResult Create(TacGia _TacGia)
        {
            return RedirectToAction("List");
        }
        // Sua TacGia duoc chon
        public ActionResult Edit(int id)
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
            ViewBag.username = "sonnx";
            TacGia TacGia = new TacGia(id, " TacGia 3");
            return View(TacGia);
        }
        [HttpPost]
        public ActionResult Edit(TacGia TacGia)
        {
            return RedirectToAction("List");
        }
        // chi tiet TacGia duoc chon
        public ActionResult Details(int id)
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
            TacGia vai = new TacGia(id, " TacGia");
            return View(vai);
        }
        [HttpPost]
        public ActionResult Details()
        {

            return RedirectToAction("List");
        }
        // xoa TacGia duoc chon   
        public ActionResult Delete(int id)
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
            ViewBag.username = "sonnx";
            TacGia TacGia = new TacGia(id, " TacGia ");
            return View(TacGia);

        }
        [HttpPost]
        public ActionResult Delete(TacGia TacGia)
        {
            return RedirectToAction("List");
        }
    }
}