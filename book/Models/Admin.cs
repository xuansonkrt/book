using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        
        public Admin()
        {

        }
        public Admin(int id, string name, string taikhoan, string matkhau)
        {
            this.Id = id;
            this.Name = name;
            this.TaiKhoan = taikhoan;
            this.MatKhau = matkhau;
        }

    }
}