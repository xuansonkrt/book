using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.Models
{
    public class CuonSach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GioiThieu { get; set; }
        public double GiaTien { get; set; }
        public int ID_TheLoai { get; set; }
        public int Id_NXB { get; set; }
        public string MainImage { get; set; }
        public int SoLuong { get; set; }
        public string TacGia { get; set; }
        public CuonSach()
        {

        }
        public CuonSach(int Id, string name, string GioiThieu, double GiaTien, int ID_TheLoai,
            int ID_NhaXuatBan, int SoLuong, string MainImage, string TacGia)
        {
            this.Id = Id;
            this.Name = name;
            this.GioiThieu = GioiThieu;
            this.GiaTien = GiaTien;
            this.ID_TheLoai = ID_TheLoai;
            this.Id_NXB = ID_NhaXuatBan;
            this.SoLuong = SoLuong;
            this.MainImage = MainImage;
            this.TacGia = TacGia;
        }
    }
}
