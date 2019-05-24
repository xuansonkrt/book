using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.Models.ViewModels
{
    public class ItemChartVM
    {
        public DateTime DAY { get; set; }
        public decimal DATA { get; set; }

        public string LABEL { get; set; }
    }
}