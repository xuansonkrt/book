using book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.Models.ViewModels
{
    public class HomeVM
    {
        public  List<BookVM> BookVMList { get; set; }
    }
}