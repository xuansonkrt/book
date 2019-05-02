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
    public class CategoryController : Controller
    {
        MyDBContext db = new MyDBContext();
        CategoryDAO dao = new CategoryDAO();

        // GET: Category
        public ActionResult Index(int? page=1, int pageSize=10)
        {
           
            int pageNumber = page ?? 1;

            // var list = dao.GetAll();
             var list = dao.GetAll2().ToPagedList(pageNumber,pageSize);
            //var list = (from l in db.Categories
            //            select l).OrderBy(x => x.Name);
            return View(list);
        }

        public ActionResult List()
        {
            return Redirect("/Category/Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category _category)
        {
            dao.Insert(_category);
            return RedirectToAction("List");
        }

        public ActionResult Edit(int ID)
        {
            Category category = dao.GetByID(ID);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category _category)
        {
            dao.Update(_category);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int ID)
        {
            Category category = dao.GetByID(ID);
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category _category)
        {
            dao.Delete(_category);
            return RedirectToAction("List");
        }


        public ActionResult Details(int ID)
        {
            Category category = dao.GetByID(ID);
            return View(category);
        }

    }
}