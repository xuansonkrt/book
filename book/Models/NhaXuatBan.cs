using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem.Models
{
    public class NhaXuatBan
    {
        public int id { get; set; }
        public String TenNhaXuatBan { get; set; }

        public NhaXuatBan()
        {

        }

        public NhaXuatBan(int id, String TenNhaXuatBan)
        {
            this.id = id;
            this.TenNhaXuatBan = TenNhaXuatBan;
        }
    }
}