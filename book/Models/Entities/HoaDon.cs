using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.Models.Entities
{
    public class HoaDon
    {
        public string Code { get; set; }
        public DateTime dateOrder { get; set; }
        public string BookName { get; set; }
        public decimal price { get; set; }
        public string Status { get; set; }
    }
}