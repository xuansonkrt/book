using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem.Models
{
    public class GioHang
    {
        public int Id { get; set; }
        public DateTime NgayThem { get; set; }
        public int Id_KhachHang { get; set; }

        public GioHang()
        {

        }

        public GioHang(int id, DateTime ngaythem, int id_KhachHang)
        {
            this.Id = id;
            this.NgayThem = NgayThem;
            this.Id_KhachHang = Id_KhachHang;
        }
    }
}