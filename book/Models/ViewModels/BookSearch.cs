using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.Models.ViewModels
{
    public class BookSearch
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string  Review { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
        public int Quanity { get; set; }
        public string MainImage { get; set; }



    }
}