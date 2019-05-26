using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.Models.Entities;
using book.DAO;

namespace book.DAO
{
    public class InvoiceDetailDAO
    {
        private MyDBContext db;

        public InvoiceDetailDAO()
        {
            db = new MyDBContext();
        }

        public int Insert(InvoiceDetail _invoiceDetail)
        {
            
            db.InvoiceDetails.Add(_invoiceDetail);
            int ret = db.SaveChanges();
            return ret;
        }
        public void Add( int IdAcc)
        {
            InvoiceDAO invoiceDAO = new InvoiceDAO();
            
            //lay id cart theo idacc
            CartUserDAO cartUserDAO = new CartUserDAO();
            int Idcart= cartUserDAO.getID(IdAcc);
            // lay list cartdetails
            var sql = "select * from CartDetail where ID_Cart= " + Idcart;
            var lstCartDetail = db.CartDetails.SqlQuery(sql).ToList();
            
            //List<InvoiceDetail> lstInvoidDetail = new List<InvoiceDetail>();
            foreach( CartDetail item in lstCartDetail)
            {
                InvoiceDetail detail = new InvoiceDetail();
                detail.ID_Book = item.ID_Book;
                detail.ID_Invoice = invoiceDAO.GetIdByAcc(IdAcc);
                detail.Quantity = item.Quantity;
                detail.Price = db.Books.Find(item.ID_Book).Price;

                db.InvoiceDetails.Add(detail);
                db.SaveChanges();
            }



        }


        //public int Update(Customer _customer)
        //{
        //    int ret = 0;
        //    Customer customer = db.Customers.Find(_customer.ID);
        //    if (customer != null)
        //    {

        //        customer.Name = _customer.Name;
        //        customer.DateOfBirth = _customer.DateOfBirth;
        //        customer.Gender = _customer.Gender;
        //        customer.Telephone = _customer.Telephone;
        //        customer.Email = _customer.Email;
        //        customer.Password = _customer.Password;
        //        ret = db.SaveChanges();
        //    }
        //    else
        //    {
        //        ret = -1;
        //    }

        //    return ret;
        //}

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

        //public Customer GetByID(int id)
        //{
        //    return db.Customers.Find(id);
        //}
        //public dynamic GetAll()
        //{
        //    var list = db.Customers.SqlQuery("SELECT * FROM Customer");

        //    return list;
        //}

        //public IEnumerable<Customer> GetAll2()
        //{
        //    var list = db.Customers.OrderBy(x => x.Name);

        //    return list;
        //}
    }
}