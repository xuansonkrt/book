using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace book.Models.ViewModels
{
    public class BookVM
    {
        public int ID { get; set; }

        [DisplayName("Tên sách")]
        public string Name { get; set; }
        [DisplayName("Giới thiệu")]
        public string Review { get; set; }

        [DisplayName("Giá")]
        public decimal? Price { get; set; }

        [DisplayName("Số lượng")]
        public int? Quantity { get; set; }

        [DisplayName("Hình ảnh")]
        public string MainImage { get; set; }
        [DisplayName("Danh mục")]
        public string CategoryName { get; set; }
        [DisplayName("Nhà xuất bản")]
        public string PublisherName { get; set; }

        [DisplayName("Tác giả")]
        public string Author { get; set; }
    }
}