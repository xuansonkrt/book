using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.DAO;
using book.Models.Entities;
using book.Models.ViewModels;
using PagedList;

namespace book.Controllers
{
    public class BookController : Controller
    {
        BookDAO dao = new BookDAO();
        CategoryDAO categoryDao = new CategoryDAO();
        PublisherDAO publisherDao = new PublisherDAO();
        // GET: Book
        public ActionResult Index(int? page = 1, int pageSize = 10)
        {
            List<BookVM> list = new List<BookVM>();
            int pageNumber = page ?? 1;
            var listBook = dao.GetAll2().ToPagedList(pageNumber, pageSize);
            foreach (var item in listBook)
            {
                BookVM vm = new BookVM();
                vm.ID = item.ID;
                vm.Name = item.Name;
                vm.Price = item.Price;
                vm.MainImage = item.MainImage;
                vm.Review = item.Review;
                vm.Quantity = item.Quantity;
                if(item.Category!=null)
                    vm.CategoryName = item.Category.Name;
                if (item.Publisher != null)
                    vm.PublisherName = item.Publisher.Name;
                list.Add(vm);
            }

            IPagedList<BookVM> pageBook = new StaticPagedList<BookVM>(list,pageNumber,pageSize,listBook.Count);
            return View(pageBook);
        }

        public ActionResult List()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            List<Category> categorys = categoryDao.GetAll();
            SelectList categoryList = new SelectList(categorys, "ID", "Name");
            ViewBag.CategoryList = categoryList;

            List<Publisher> publishers = publisherDao.GetAll();
            SelectList publisherList = new SelectList(publishers, "ID", "Name");
            ViewBag.PublisherList = publisherList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book _book)
        {
            dao.Insert(_book);
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            Book book = dao.GetByID(id);
            List<Category> categorys = categoryDao.GetAll();
            SelectList categoryList = new SelectList(categorys, "ID", "Name");
            ViewBag.CategoryList = categoryList;

            List<Publisher> publishers = publisherDao.GetAll();
            SelectList publisherList = new SelectList(publishers, "ID", "Name");
            ViewBag.PublisherList = publisherList;

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book _book)
        {
            int ret = dao.Update(_book);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Book book = dao.GetByID(id);
            BookVM vm = new BookVM();
            vm.ID = book.ID;
            vm.Name = book.Name;
            vm.Price = book.Price;
            vm.MainImage = book.MainImage;
            vm.Review = book.Review;
            vm.Quantity = book.Quantity;
            if (book.Category != null)
                vm.CategoryName = book.Category.Name;
            if (book.Publisher != null)
                vm.PublisherName = book.Publisher.Name;
            return View(vm);
        }

        public ActionResult Delete(int id)
        {
            Book book = dao.GetByID(id);
            BookVM vm = new BookVM();
            vm.ID = book.ID;
            vm.Name = book.Name;
            vm.Price = book.Price;
            vm.MainImage = book.MainImage;
            vm.Review = book.Review;
            vm.Quantity = book.Quantity;
            if (book.Category != null)
                vm.CategoryName = book.Category.Name;
            if (book.Publisher != null)
                vm.PublisherName = book.Publisher.Name;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Delete(Book _book)
        {
            dao.Delete(_book);
            return RedirectToAction("List");
        }
    }
}