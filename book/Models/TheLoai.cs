using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem.Models
{
    public class TheLoai
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TheLoai()
        {
            
        }
        public TheLoai(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}