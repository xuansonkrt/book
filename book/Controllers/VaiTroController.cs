using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagementSystem.Models;

namespace BookManagementSystem.Controllers
{
    public class VaiTroController : Controller
    {
        // GET: VaiTro
        public ActionResult Index()
        {
            return View();
        }
        // tao list VaiTro
        public ActionResult List()
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
            List<VaiTro> list = new List<VaiTro>();
            for(int i= 0; i<=3; i++)
            {
                VaiTro vaiTro = new VaiTro();
                vaiTro.ID = i;
                vaiTro.NameVaiTro = " vai tro " + i;
                list.Add(vaiTro);
            }
            return View(list);
        }
        //tao vai tro moi
        public ActionResult Create()
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
            return View();
        }
        [HttpPost]
        public ActionResult Create(VaiTro _VaiTro)
        {
            return RedirectToAction("List");
        }
        // Sua vai tro duoc chon
        public ActionResult Edit(int id)
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
            VaiTro VaiTro = new VaiTro(id, " vai tro 2");
            return View(VaiTro);
        }
        [HttpPost]
        public ActionResult Edit(VaiTro VaiTro)
        {
            return RedirectToAction("List");
        }
        // chi tiet vai tro duoc chon
        public ActionResult Details(int id)
        {
            if (Session["username"] == null)
                return Redirect("/Admin/Login");
            VaiTro vai = new VaiTro(id, "vai tro");
            return View(vai);
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
            VaiTro VaiTro = new VaiTro(id, "vai tro ");
            return View(VaiTro);

        }
        [HttpPost]
        public ActionResult Delete(VaiTro VaiTro)
        {
            return RedirectToAction("List");
        }
    }
}