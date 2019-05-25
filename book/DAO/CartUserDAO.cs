using book.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.DAO
{
    public class CartUserDAO
    {
        private MyDBContext db;
        public CartUserDAO()
        {
            db = new MyDBContext();
        
        }
        public int getID(int id)// get id cart
        {   
            var sql = " select * from Cart where ID_Account = " + id;
            var lst = db.Carts.SqlQuery(sql).ToList();
            if(lst.Count == 0)
            {
                return -1;
            }

            return lst[0].ID;
        }
        public int? GetQuanity( int idbook, int idcart)
       
        {
            var sql = " select * from CartDetail where ID_Book=" + idbook + " and ID_Cart=" + idcart;
            var lst = db.CartDetails.SqlQuery(sql).ToList();
            if( lst.Count == 0  )
            {
                return -1;
            }
            return lst[0].Quantity;
        }
        public int GetAmount( int id)
        {
            var sql = "exec Dem " + id;
            var lst = db.Database.SqlQuery<int>(sql).FirstOrDefault();
            return lst;
                                 
        }
        public int GetTotal( int idcart)
        {
            var sql = " select SUM ([Quantity]) from CartDetail where ID_Cart =" + idcart;
            var lst = db.Database.SqlQuery<int>(sql).ToList().FirstOrDefault();
            return lst;
        }
        

    }
}