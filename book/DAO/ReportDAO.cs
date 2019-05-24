using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.Models.Entities;
using book.Models.ViewModels;

namespace book.DAO
{
    public class ReportDAO
    {
        private MyDBContext db;

        public ReportDAO()
        {
            db = new MyDBContext();
        }

        public decimal TotalPriceOfWeek()
        {
            return db.Database.SqlQuery<decimal>("EXEC TotalPriceOfWeek").FirstOrDefault();
        }

        public int TotalOrderOfWeek()
        {
            var value = db.Database.SqlQuery<int>("EXEC TotalOrderOfWeek").FirstOrDefault();
            return value;
        }


        public dynamic ProfitInWeek()
        {
             var list = db.Database.SqlQuery<ItemChartVM>("EXEC ProfitInWeek").ToList();
             int x = 0;
              return list;
        }
    }
}