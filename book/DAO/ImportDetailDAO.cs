using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.Models.Entities;

namespace book.DAO
{
    public class ImportDetailDAO
    {
        private MyDBContext db;

        public ImportDetailDAO()
        {
            db= new MyDBContext();
        }

        public List<ImportDetail> GetList(int  id)
        {
            return db.ImportDetails.Where(x => x.ImportID == id).ToList();
        }
    }
}