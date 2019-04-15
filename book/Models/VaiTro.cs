using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem.Models
{
    public class VaiTro
    {
        public int ID { get; set; }
        public string NameVaiTro { get; set; }
        public VaiTro()
        {
               
        }
        public VaiTro( int id, string nam)
        {
            this.ID = id;
            this.NameVaiTro = nam;
        }


    }
}