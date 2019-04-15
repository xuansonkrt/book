using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem.Models
{
    public class KhachHang
    {
        public int id { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string SDT { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgayDK { get; set; }

        public KhachHang()
        {

        }

        public KhachHang(int id, string HoTen, string Email, string MatKhau
            , string SDT, int GioiTinh, DateTime NgayDK )
        {
            this.id = id;
            this.HoTen = HoTen;
            this.Email = Email;
            this.MatKhau = MatKhau;
            this.SDT = SDT;
            this.GioiTinh = GioiTinh;
            this.NgayDK = NgayDK;
        }

    }
}