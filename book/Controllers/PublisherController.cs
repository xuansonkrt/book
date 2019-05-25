using book.DAO;
using book.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace book.Controllers
{
    public class PublisherController : Controller
    {
        PublisherDAO dao = new PublisherDAO();

        // GET: Category
        public ActionResult Index(int? page=1, int pageSize=10)
        {
            if (!(bool)Session["isAdmin"])
            {
                return Redirect("/Admin/Login");
            }
            int pageNumber = page ?? 1;
            var list = dao.GetAll2().ToPagedList(pageNumber,pageSize);

            return View(list);
        }

        public ActionResult List()
        {
            if (!(bool)Session["isAdmin"])
            {
                return Redirect("/Admin/Login");
            }
            return Redirect("/Publisher/Index");
        }

        public ActionResult Create()
        {
            if (!(bool)Session["isAdmin"])
            {
                return Redirect("/Admin/Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Publisher _publisher)
        {
            dao.Insert(_publisher);
            return RedirectToAction("List");
        }

        public ActionResult Edit(int ID)
        {
            if (!(bool)Session["isAdmin"])
            {
                return Redirect("/Admin/Login");
            }
            Publisher publisher = dao.GetByID(ID);
            return View(publisher);
        }

        [HttpPost]
        public ActionResult Edit(Publisher _publisher)
        {
            dao.Update(_publisher);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int ID)
        {
            if (!(bool)Session["isAdmin"])
            {
                return Redirect("/Admin/Login");
            }
            Publisher publisher = dao.GetByID(ID);
            return View(publisher);
        }

        [HttpPost]
        public ActionResult Delete(Publisher _publisher)
        {
            dao.Delete(_publisher);
            return RedirectToAction("List");
        }


        public ActionResult Details(int ID)
        {
            if (!(bool)Session["isAdmin"])
            {
                return Redirect("/Admin/Login");
            }
            Publisher publisher = dao.GetByID(ID);
            return View(publisher);
        }
    }
}