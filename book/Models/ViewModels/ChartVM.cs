using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.Models.ViewModels
{
    public class ChartVM
    {
        public List<ItemChartVM> list { get; set; }

        public ChartVM()
        {
            list = new List<ItemChartVM>();
        }
    }
}