using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.DAO;
using book.Models.Entities;
using PagedList;

namespace book.Controllers
{
    public class AuthorController : Controller
    {
        AuthorDAO dao = new AuthorDAO();
        // GET: Author
        //public ActionResult Index(int? page=1, int pageSize=10)
        //{
        //    if ((Session["username"] == null))
        //    {
        //        return Redirect("/Admin/Login");
        //    }
        //    int pageNumber = page ?? 1;
        //    var list = dao.GetAll2().ToPagedList(pageNumber, pageSize);
        //    return View(list);
        //}

        //public ActionResult List()
        //{
        //    if ((Session["username"] == null))
        //    {
        //        return Redirect("/Admin/Login");
        //    }
        //    return RedirectToAction("Index");
        //}

        public ActionResult Create()
        {
            if ((Session["username"] == null))
            {
                return Redirect("/Admin/Login");
            }
            return View();
        }

        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult Create( Author _author)
        //{//HttpPostedFileBase image,
        //    int ret = dao.Insert(_author);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Edit(int id)
        //{
        //    if ((Session["username"] == null))
        //    {
        //        return Redirect("/Admin/Login");
        //    }
        //    Author author = dao.GetByID(id);
        //    return View(author);
        //}

        //[HttpPost]
        //public ActionResult Edit(Author _author)
        //{
        //    int ret = dao.Update(_author);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Details(int id)
        //{
        //    if ((Session["username"] == null))
        //    {
        //        return Redirect("/Admin/Login");
        //    }
        //    Author author = dao.GetByID(id);
        //    return View(author);
        //}

        //public ActionResult Delete(int id)
        //{
        //    if ((Session["username"] == null))
        //    {
        //        return Redirect("/Admin/Login");
        //    }
        //    Author author = dao.GetByID(id);
        //    return View(author);
        //}

        //[HttpPost]
        //public ActionResult Delete(Author author)
        //{
        //    dao.Delete(author);
        //    return RedirectToAction("List");
        //}
    }
}