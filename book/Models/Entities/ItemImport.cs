using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.Models.Entities
{
    public class ItemImport
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Amount { get; set; }
    }
}