using book.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.DAO
{
    public class PublisherDAO
    {
        MyDBContext db;
        public PublisherDAO()
        {
            db = new MyDBContext();
        }

        public int Insert(Publisher _publisher)
        {
            int ret = 0;
            Publisher publisher = new Publisher();
            publisher.Name = _publisher.Name;
            publisher.Date = _publisher.Date;
            publisher.Description = _publisher.Description;
            db.Publishers.Add(publisher);
            ret = db.SaveChanges();
            return ret;
        }


        public int Update(Publisher _publisher)
        {
            int ret = 0;
            Publisher publisher = db.Publishers.Find(_publisher.ID);
            if (publisher != null)
            {

                publisher.Name = _publisher.Name;
                publisher.Date = _publisher.Date;
                publisher.Description = _publisher.Description;
                ret = db.SaveChanges();
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        public int Delete(Publisher _publisher)
        {
            int ret = 0;
            Publisher publisher = db.Publishers.Find(_publisher.ID);
            if (publisher != null)
            {

                db.Publishers.Remove(publisher);
                ret = db.SaveChanges();
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        public Publisher GetByID(int id)
        {
            return db.Publishers.Find(id);
        }
        public List<Publisher> GetAll()
        {
           // var list = db.Publishers.SqlQuery("SELECT * FROM Publisher");

            return db.Publishers.ToList();
        }

        public IEnumerable<Publisher> GetAll2()
        {
            var list = db.Publishers.OrderBy(x=>x.Date);

            return list;
        }
    }
}