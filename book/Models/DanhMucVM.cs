using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem.Models
{
    public class DanhMucVM
    {
        public List<TheLoai> ListTheLoai { get; set; }
        public List<CuonSach> ListCuonSach { get; set; }
    }
}