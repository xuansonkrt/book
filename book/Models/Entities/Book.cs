using System.ComponentModel;

namespace book.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            CartDetails = new HashSet<CartDetail>();
            InvoiceDetails = new HashSet<InvoiceDetail>();
            CouponDetails = new HashSet<CouponDetail>();
            Rates = new HashSet<Rate>();
            ListImages = new HashSet<ListImage>();
            WriteBooks = new HashSet<WriteBook>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Tên sách")]
        public string Name { get; set; }

        [StringLength(1000)]
        [DisplayName("Giới thiệu")]
        public string Review { get; set; }

        [DisplayName("Giá")]
        public decimal? Price { get; set; }

        [DisplayName("Mã danh mục")]
        public int? ID_Category { get; set; }

        [DisplayName("Mã nhà xuất bản")]
        public int? ID_Publisher { get; set; }

        [DisplayName("Số lượng")]
        public int? Quantity { get; set; }

        [StringLength(1000)]
        [DisplayName("Hình ảnh")]
        public string MainImage { get; set; }

        public virtual Publisher Publisher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartDetail> CartDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CouponDetail> CouponDetails { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListImage> ListImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WriteBook> WriteBooks { get; set; }
    }
}
