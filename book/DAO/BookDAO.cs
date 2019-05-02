using book.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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

                db.Books.Remove(book);
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

        public IEnumerable<Book> GetAll2()
        {
            var list = db.Books.OrderBy(x => x.Name);

            return list;
        }

        public dynamic GetByCategory(int categoryId)
        {
            var list = db.Books.SqlQuery("SELECT * FROM Book WHERE ID_Category=@categoryID", new SqlParameter("categoryId", categoryId));

            return list;
        }
        public dynamic GetByPublisher(int publisherId)
        {
            var list = db.Books.SqlQuery("SELECT * FROM Book WHERE ID_Publisher=@publisherId", new SqlParameter("publisherId", publisherId));
            return list;
        }
    }
}