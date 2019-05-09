using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.Models.Entities;

namespace book.DAO
{
   
    public class InvoiceStatusDAO
    {
        private MyDBContext db;

        public InvoiceStatusDAO()
        {
            db = new MyDBContext();
        }

        public List<InvoiceStatu> GetAll()
        {
            // var list = db.Publishers.SqlQuery("SELECT * FROM Publisher");

            return db.InvoiceStatus.ToList();
        }
    }
}