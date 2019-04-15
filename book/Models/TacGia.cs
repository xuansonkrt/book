using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem.Models
{
    public class TacGia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TacGia()
        {
            this.Id = 0;
            this.Name = "";
        }
        public TacGia( int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}