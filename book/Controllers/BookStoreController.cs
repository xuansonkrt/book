using System;
using book.Models.ViewModels;
using book.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.DAO;
using book.Models.Entities;
using PagedList;

namespace Web_BookStore1.Controllers
{
    public class BookStoreController : Controller
    {
        MyDBContext db = new MyDBContext();
        // GET: BookStore
        public ActionResult Index(int? page = 1, int pageSize = 3)
        {
           // HomeVM vm = new HomeVM();
            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = categoryList;

            List<Publisher> publisherList = db.Publishers.ToList();
            ViewBag.PublisherList = publisherList;

            List<Book> books = new List<Book>();
            books = db.Books.ToList();
            List<BookVM> list = new List<BookVM>();
            foreach (var item in books)
            {
                BookVM bookVM = new BookVM();
                bookVM.ID = item.ID;
                bookVM.Name = item.Name;
                bookVM.Price = item.Price;
                bookVM.MainImage = item.MainImage;
                bookVM.Review = item.Review;
                bookVM.Quantity = item.Quantity;
                if (item.Category != null)
                    bookVM.CategoryName = item.Category.Name;
                if (item.Publisher != null)
                    bookVM.PublisherName = item.Publisher.Name;
                
                list.Add(bookVM);
            }

         //   Session["cartAmount"] = 0;
            int pageNumber = page ?? 1;
        //    IPagedList<BookVM> pageBook = new StaticPagedList<BookVM>(list, pageNumber, pageSize, list.Count);
            var vm = new HomeVM
            {
                //  ListTheLoai = listtheloai,
                BookVMList = list
            };
            return View(vm);
        }
       
        public ActionResult SachBanChay()
        {
            return View();
        }
        public ActionResult TieuThuyet()
        {
            return View();
        }

        public ActionResult TheLoai(string id)
        {
            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = categoryList;

            List<Publisher> publisherList = db.Publishers.ToList();
            ViewBag.PublisherList = publisherList;

            BookDAO bookDao= new BookDAO();
            var books = bookDao.GetByCategory(Int32.Parse(id));
            List<BookVM> list = new List<BookVM>();
            foreach (var item in books)
            {
                BookVM bookVM = new BookVM();
                bookVM.ID = item.ID;
                bookVM.Name = item.Name;
                bookVM.Price = item.Price;
                bookVM.MainImage = item.MainImage;
                bookVM.Review = item.Review;
                bookVM.Quantity = item.Quantity;
                if (item.Category != null)
                    bookVM.CategoryName = item.Category.Name;
                if (item.Publisher != null)
                    bookVM.PublisherName = item.Publisher.Name;

                list.Add(bookVM);
            }

            var vm = new HomeVM
            {
                //  ListTheLoai = listtheloai,
                BookVMList = list
            };
            return View("~/Views/BookStore/Index.cshtml",vm);
        }


        public ActionResult NXB(string id)
        {
            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = categoryList;

            List<Publisher> publisherList = db.Publishers.ToList();
            ViewBag.PublisherList = publisherList;

            BookDAO bookDao = new BookDAO();
            var books = bookDao.GetByPublisher(Int32.Parse(id));
            List<BookVM> list = new List<BookVM>();
            foreach (var item in books)
            {
                BookVM bookVM = new BookVM();
                bookVM.ID = item.ID;
                bookVM.Name = item.Name;
                bookVM.Price = item.Price;
                bookVM.MainImage = item.MainImage;
                bookVM.Review = item.Review;
                bookVM.Quantity = item.Quantity;
                if (item.Category != null)
                    bookVM.CategoryName = item.Category.Name;
                if (item.Publisher != null)
                    bookVM.PublisherName = item.Publisher.Name;

                list.Add(bookVM);
            }

            var vm = new HomeVM
            {
                //  ListTheLoai = listtheloai,
                BookVMList = list
            };
            return View("~/Views/BookStore/Index.cshtml", vm);
        }

        public ActionResult Detail(string id)
        {
            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = categoryList;

            List<Publisher> publisherList = db.Publishers.ToList();
            ViewBag.PublisherList = publisherList;

            //int i = Int32.Parse(id);
            BookDAO bookDao = new BookDAO();
            Book book = bookDao.GetByID(Int32.Parse(id));
            BookVM bookVM = new BookVM();
            bookVM.ID = book.ID;
            bookVM.Name = book.Name;
            bookVM.Price = book.Price;
            bookVM.MainImage = book.MainImage;
            bookVM.Review = book.Review;
            bookVM.Quantity = book.Quantity;
            if (book.Category != null)
                bookVM.CategoryName = book.Category.Name;
            if (book.Publisher != null)
                bookVM.PublisherName = book.Publisher.Name;
            return View(bookVM);
        }



    }
}