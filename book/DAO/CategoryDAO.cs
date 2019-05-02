using book.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.DAO
{
    public class CategoryDAO
    {
        MyDBContext db;
        public CategoryDAO()
        {
            db = new MyDBContext();
        }

        public int Insert(Category _category)
        {
            int ret = 0;
            Category category = new Category();
            category.Name = _category.Name;
            db.Categories.Add(category);
            ret = db.SaveChanges();
            return ret;
        }


        public int Update(Category _category)
        {
            int ret = 0;
            Category category = db.Categories.Find(_category.ID);
            if (category != null)
            {

                category.Name = _category.Name;
                ret = db.SaveChanges();
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        public int Delete(Category _category)
        {
            int ret = 0;
            Category category = db.Categories.Find(_category.ID);
            if (category != null)
            {

                db.Categories.Remove(category);
                ret = db.SaveChanges();
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        public Category GetByID(int id)
        {
            return db.Categories.Find(id);
        }
        public List<Category> GetAll()
        {
           // var list = db.Categories.SqlQuery("SELECT * FROM Category ORDER BY Name");

            return db.Categories.ToList();
        }

        public IEnumerable<Category> GetAll2()
        {
            return db.Categories.OrderBy(x=>x.Name);
        }
    }
}