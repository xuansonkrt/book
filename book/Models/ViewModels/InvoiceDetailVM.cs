using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.Models.Entities;

namespace book.Models.ViewModels
{
    public class InvoiceDetailVM
    {
        public Customer customer { get; set; }
        public List<Item> list { get; set; }
        public Invoice invoice { get; set; }
    }
}