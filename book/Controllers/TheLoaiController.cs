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
        public  static List<TheLoai> list = new List<TheLoai>();

        public TheLoaiController()
        {
            for (int i = 0; i < 10; i++)
            {
                list.Add(new TheLoai(i, "The loai " + i));
            }
            //Session["list"] = list;
            //  Global.Global.ListTheLoai = list;

        }

        // GET: TheLoai
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult List()
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
            ViewBag.username = "sonx";
            ViewBag.avatar = "/Content/images/IMG_9405-3.jpg";
            //var list = Global.Global.ListTheLoai;
            return View(list);
        }


        public ActionResult Create()
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
            ViewBag.username = "sonx";
            return View();
        }
        [HttpPost]
        public ActionResult Create(TheLoai _theLoai)
        {
            //var list = Session["list"];
            
            
            //save to db
          //  var list = Global.Global.ListTheLoai;
            _theLoai.ID = list.Count + 1;
            list.Add(_theLoai);
           // Global.Global.ListTheLoai = list;
            return RedirectToAction("List");
        }
        // Sua the loai duoc chon
        public ActionResult Edit(int id)
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
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
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
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
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
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