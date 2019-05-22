using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.DAO;
using book.Models.Entities;
using PagedList;

namespace book.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDAO dao  =new CustomerDAO(); 
        // GET: Customer
        //public ActionResult Index(int? page = 1, int pageSize = 10)
        //{
        //    int pageNumber = page ?? 1;
        //    var list = dao.GetAll2().ToPagedList(pageNumber, pageSize);
        //    return View(list);
        //}

        //public ActionResult List()
        //{
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Customer _customer)
        //{
        //    int ret = dao.Insert(_customer);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Edit(int id)
        //{
        //    Customer customer= dao.GetByID(id);
        //    return View(customer);
        //}

        //[HttpPost]
        //public ActionResult Edit(Customer _customer)
        //{
        //    int ret = dao.Update(_customer);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Details(int id)
        //{
        //    Customer customer = dao.GetByID(id);
        //    return View(customer);
        //}

        //public ActionResult Delete(int id)
        //{
        //    Customer customer = dao.GetByID(id);
        //    return View(customer);
        //}

        //[HttpPost]
        //public ActionResult Delete(Customer _customer)
        //{
        //    dao.Delete(_customer);
        //    return RedirectToAction("List");
        //}
    }
}