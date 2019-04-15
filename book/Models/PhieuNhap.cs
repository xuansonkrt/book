using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem.Models
{
    public class PhieuNhap
    {
        public int Id { get; set; }
        public DateTime NgayNhap { get; set; }
        public int Id_Admin { get; set; }

        public PhieuNhap()
        {

        }

        public PhieuNhap(int id, DateTime ngaynhap, int id_Admin)
        {
            this.Id = id;
            this.NgayNhap = ngaynhap;
            this.Id_Admin = id_Admin;
        }
    }
}