using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem.Models
{
    public class HoaDon
    {
        public int id { get; set; }
        public int idKhachHang { get; set; }
        public string MaGiamGia { get; set; }
        public double TongTien { get; set; }

        public DateTime NgayDatHang { get; set; }
        public DateTime NgayGiaoHang { get; set; }

        public HoaDon()
        {

        }

        public HoaDon(int id, int idKhachHang, string MaGiamGia, double TongTien
            ,DateTime NgayDatHang, DateTime NgayGiaoHang)
        {
            this.id = id;
            this.idKhachHang = idKhachHang;
            this.MaGiamGia = MaGiamGia;
            this.TongTien = TongTien;
            this.NgayDatHang = NgayDatHang;
            this.NgayGiaoHang = NgayGiaoHang;
        }
    }
}