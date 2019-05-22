using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.Global
{
    public class MyFunction
    {
        public static string convert2String(double price)
        {
            string result = price.ToString("##,###");
            return result;
        }

        public static string convert2String(decimal? price)
        {
            double temp =(double) price.Value;
            string result = temp.ToString("##,###");
            return result;
        }

        public static string convert2String(DateTime? date)
        {
            return ((DateTime) date).ToString("dd/MM/yyyy");
        }
    }
}