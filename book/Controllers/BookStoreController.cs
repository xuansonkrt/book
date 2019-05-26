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
using System.Data.SqlClient;

namespace Web_BookStore1.Controllers
{
    public class BookStoreController : Controller
    {
        MyDBContext db = new MyDBContext();
        // GET: BookStore
        public ActionResult Index(int? page = 1, int pageSize = 9)
        {

            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = categoryList;

            List<Publisher> publisherList = db.Publishers.ToList();
            ViewBag.PublisherList = publisherList;
            

            List<Book> books = new List<Book>();
            string _publisherId = Request.QueryString["publisherId"];
            string _categoryId = Request.QueryString["categoryId"];
            string _price1 = Request.QueryString["price1"];
            string _price2 = Request.QueryString["price2"];
            int categoryId = 0, publisherId = 0;
            decimal price1 = 0, price2 = 0;
            if (_publisherId != null)
            {
                publisherId = Int32.Parse(_publisherId);
            }
            if (_categoryId != null)
            {
                categoryId = Int32.Parse(_categoryId);
            }
            if (_price1 != null)
            {
                price1 = decimal.Parse(_price1);
            }
            if (_price2 != null)
            {
                price2 = decimal.Parse(_price2);
            }

            books = db.Books.SqlQuery("exec Loc @categoryId, @publisherId,@price1,@price2",
               new SqlParameter("categoryId", categoryId),
               new SqlParameter("publisherId", publisherId),
                new SqlParameter("price1", price1),
                 new SqlParameter("price2", price2)
               ).ToList();
            List <BookVM> list = new List<BookVM>();
        
            int pageNumber = page ?? 1;
        
            return View(books.ToPagedList(pageNumber, pageSize));
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
        public ActionResult TimKiem( string SearchString)
        {
            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = categoryList;

            List<Publisher> publisherList = db.Publishers.ToList();
            ViewBag.PublisherList = publisherList;


            var links = from l in db.Books
                        select l;

            if (!string.IsNullOrEmpty(SearchString))
            {
                links = links.Where(s => s.Name.Contains(SearchString));
            }

            return View(links.ToList());
        }
        public ActionResult Inf()
        {
            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = categoryList;

            List<Publisher> publisherList = db.Publishers.ToList();
            ViewBag.PublisherList = publisherList;
            return View();
        }

    }
}