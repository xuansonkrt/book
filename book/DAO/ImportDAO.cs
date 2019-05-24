using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.Models.Entities;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Facebook;

namespace book.DAO
{
    public class ImportDAO
    {
        private MyDBContext db;

        public ImportDAO()
        {
            db = new MyDBContext();
        }

        public List<Import> GetAll()
        {
            return db.Imports.ToList();
        }

        public int Add(List<ItemImport> lst, int accountID, decimal totalPrice)
        {
            Import import = new Import();
            import.CreatedDate = DateTime.Now;
            import.AccountID = accountID;
            import.AccountID = accountID;
            import.TotalPrice = totalPrice;
            int ret;
            db.Imports.Add(import);
            ret = db.SaveChanges();
            if (ret > 0)
            {
                foreach (var item in lst)
                {
                    ImportDetail detail = new ImportDetail();
                    detail.ImportID = import.ID;
                    detail.Amount =(int) item.Amount;
                    detail.Price = item.Price;
                    detail.BookID = item.ID;

                    BookDAO bookDao = new BookDAO();
                    ret = bookDao.ChangeAmount(item.ID,(int) item.Amount);
                   
                    db.ImportDetails.Add(detail);
                    ret = db.SaveChanges();
                    if (ret < 0)
                    {
                        break;
                    }
                }

                
            }

            return ret;
        }
    }
}