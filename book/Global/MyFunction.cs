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
            if (price == null)
                return "0";
            string result = price.ToString("##,###");
            return result;
        }

        public static string convert2String(decimal? price)
        {
            if (price == null)
                return "0";
            double temp =(double) price.Value;
            string result = temp.ToString("##,###");
            return result;
        }

        public static string convert2String(DateTime? date)
        {
            if (date == null)
                return "";
            return ((DateTime) date).ToString("dd/MM/yyyy");
        }
    }
}