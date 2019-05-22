using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.Models.Entities;
using System.Data.SqlClient;

namespace book.DAO
{
    public class InvoiceDAO
    {
        private MyDBContext db;

        public InvoiceDAO()
        {
            db = new MyDBContext();
        }

        public int Insert(Invoice _invoice)
        {
            
            db.Invoices.Add(_invoice);
            int ret = db.SaveChanges();
            return ret;
        }


        public int Update(Invoice _invoice)
        {
            int ret = 0;
            Invoice invoice = db.Invoices.Find(_invoice.ID);
            if (invoice != null)
            {
                invoice.ID_InvoiceStatus = _invoice.ID_InvoiceStatus;
                ret = db.SaveChanges();
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        //public int Delete(Customer _customer)
        //{
        //    int ret = 0;
        //    Customer customer = db.Customers.Find(_customer.ID);
        //    if (customer != null)
        //    {

        //        db.Customers.Remove(customer);
        //        ret = db.SaveChanges();
        //    }
        //    else
        //    {
        //        ret = -1;
        //    }

        //    return ret;
        //}

        public Invoice GetByID(int id)
        {
            return db.Invoices.Find(id);
        }
        public dynamic GetAll()
        {
            var list = db.Invoices.SqlQuery("SELECT * FROM Invoice");

            return list;
        }

        public IEnumerable<Invoice> GetAll2(int invoiceStatusID, string keyword)
        {
        //    var list = db.Invoices.OrderBy(x => x.OrderDate);
        var list = db.Invoices.SqlQuery("EXEC Invoice_GetAllSearch @invoiceStatusID, @keyword",
            new SqlParameter("invoiceStatusID", invoiceStatusID),
            new SqlParameter("keyword", keyword)).ToList();
            return list;
        }

        public IEnumerable<Invoice> GetAllByStatus(int ID)
        {
            var list = db.Invoices.OrderBy(x => x.OrderDate);

            return list;
        }

    }
}