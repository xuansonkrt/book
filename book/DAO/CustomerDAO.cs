using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.Models.Entities;

namespace book.DAO
{
    public class CustomerDAO
    {
        private MyDBContext db;

        public CustomerDAO()
        {
            db = new MyDBContext();
        }

        public int Insert(Customer _customer)
        {
            _customer.join_Date=DateTime.Now;
            db.Customers.Add(_customer);
            int ret = db.SaveChanges();
            return ret;
        }


        public int Update(Customer _customer)
        {
            int ret = 0;
            Customer customer = db.Customers.Find(_customer.ID);
            if (customer != null)
            {

                customer.Name = _customer.Name;
                customer.DateOfBirth = _customer.DateOfBirth;
                customer.Gender = _customer.Gender;
                customer.Telephone = _customer.Telephone;
                customer.Email = _customer.Email;
                customer.Password = _customer.Password;
                ret = db.SaveChanges();
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        public int Delete(Customer _customer)
        {
            int ret = 0;
            Customer customer = db.Customers.Find(_customer.ID);
            if (customer != null)
            {

                db.Customers.Remove(customer);
                ret = db.SaveChanges();
            }
            else
            {
                ret = -1;
            }

            return ret;
        }

        public Customer GetByID(int id)
        {
            return db.Customers.Find(id);
        }
        public dynamic GetAll()
        {
            var list = db.Customers.SqlQuery("SELECT * FROM Customer");

            return list;
        }

        public IEnumerable<Customer> GetAll2()
        {
            var list = db.Customers.OrderBy(x => x.Name);

            return list;
        }
    }
}