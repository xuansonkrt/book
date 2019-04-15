using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem.Models
{
    public class ListImage
    {
        public int ID { get; set; }
        public int ID_CuonSach { get; set; }
        public string link { get; set; }
        public ListImage()
        {

        }
        public ListImage( int id, int IDCuonSach, string link)
        {
            this.ID = id;
            this.ID_CuonSach = IDCuonSach;
            this.link = link;
        }
    }
}