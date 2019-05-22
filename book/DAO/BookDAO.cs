using book.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList;

namespace book.DAO
{
    public class BookDAO
    {
        private MyDBContext db;

        public BookDAO()
        {
            db = new MyDBContext();
        }

        public int Insert(Book book)
        {
            book.Status = 1;
            db.Books.Add(book);
            int ret = db.SaveChanges();
            return ret;
        }


        public int Update(Book _book)
        {
            int ret = 0;
            Book book = db.Books.Find(_book.ID);
            if (book != null)
            {

                book.Name = _book.Name;
                book.Review = _book.Review;
                book.Price = _book.Price;
                book.Quantity = _book.Quantity;
                book.MainImage = _book.MainImage;
                book.ID_Category = _book.ID_Category;
                book.ID_Publisher = _book.ID_Publisher;
                ret = db.SaveChanges();
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        public int Delete(Book _book)
        {
            int ret = 0;
            Book book = db.Books.Find(_book.ID);
            if (book != null)
            {

                //db.Books.Remove(book);
                book.Status = 0;
                ret = db.SaveChanges();
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        public Book GetByID(int id)
        {
            return db.Books.Find(id);
        }
        public dynamic GetAll()
        {
            var list = db.Books.SqlQuery("SELECT * FROM Book");

            return list;
        }

        public IEnumerable<Book> GetAll2(int? categoryId, int? min, int? max
                        , string keyWord)
        {
            // var list = db.Books.OrderBy(x => x.Name);
            MyDBContext db2 = new MyDBContext();
            var list = db2.Books.SqlQuery("exec Book_GetAllSearch @categoryId, @min, @max, @keyWord ",
                new SqlParameter("categoryId", categoryId),
                new SqlParameter("min", min),
                new SqlParameter("max", max),
                new SqlParameter("keyWord", keyWord)).ToList();
            // var list = db2.Books.SqlQuery("select * from Book").ToList();
            return list;
            //if (categoryId == 0)
            //{
            //    return from b in db.Books
            //        where min <= b.Price && max >= b.Price && b.Name.Contains(@"/"+keyWord+"/")
            //              && b.Review.Contains(@"/" + keyWord + "/")
            //           select b;
            //}
            //else
            //{
            //    return from b in db.Books
            //        where categoryId==b.ID_Category && min <= b.Price && max >= b.Price
            // && b.Name.Contains(@"/" + keyWord + "/")
            //              && b.Review.Contains(@"/" + keyWord + "/")
            //           select b;
            //}
        }

        public dynamic GetByCategory(int categoryId)
        {
            var list = db.Books.SqlQuery("SELECT * FROM Book WHERE ID_Category=@categoryID"
                , new SqlParameter("categoryId", categoryId));

            return list;
        }
        public dynamic GetByPublisher(int publisherId)
        {
            var list = db.Books.SqlQuery("SELECT * FROM Book WHERE ID_Publisher=@publisherId"
                , new SqlParameter("publisherId", publisherId));
            return list;
        }
    }
}