using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using book.Models.Entities;

namespace book.DAO
{
    public class AuthorDAO
    {
        private MyDBContext db;

        public AuthorDAO()
        {
            db= new MyDBContext();
        }

        public int Insert(Author author)
        {
            db.Authors.Add(author);
            int ret = db.SaveChanges();
            return ret;
        }


        public int Update(Author _author)
        {
            int ret = 0;
            Author author = db.Authors.Find(_author.ID);
            if (author != null)
            {

                author.Name = _author.Name;
                author.DateOfBirth = _author.DateOfBirth;
                author.Gender = _author.Gender;
                author.Address = _author.Address;
                author.Email = _author.Email;
                author.Description = _author.Description;
                author.Avatar = _author.Avatar;
                ret = db.SaveChanges();
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        public int Delete(Author _author)
        {
            int ret = 0;
            Author author = db.Authors.Find(_author.ID);
            if (author != null)
            {

                db.Authors.Remove(author);
                ret = db.SaveChanges();
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        public Author GetByID(int id)
        {
            return db.Authors.Find(id);
        }
        public dynamic GetAll()
        {
            var list = db.Authors.SqlQuery("SELECT * FROM Author");

            return list;
        }

        public IEnumerable<Author> GetAll2()
        {
            var list = db.Authors.OrderBy(x => x.Name);

            return list;
        }
    }
}