using BookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<TheLoai> ListTheLoai { get; set; }

        public IEnumerable<CuonSach> ListCuonSach { get; set; }
    }
}