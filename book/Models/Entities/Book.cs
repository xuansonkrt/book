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
            ImportDetails = new HashSet<ImportDetail>();
            ListImages = new HashSet<ListImage>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên sách")]
        public string Name { get; set; }

        [StringLength(1000)]
        [Display(Name = "Giới thiệu")]
        public string Review { get; set; }
        [Display(Name = "Giá")]
        public decimal? Price { get; set; }
        [Display(Name = "Thể loại")]
        public int? ID_Category { get; set; }
        [Display(Name = "Nhà xuất bản")]
        public int? ID_Publisher { get; set; }
        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [StringLength(1000)]
        [Display(Name = "Hình ảnh")]
        public string MainImage { get; set; }

        [StringLength(500)]
        [Display(Name = "Tác giả")]
        public string Author { get; set; }

        public int? Status { get; set; }

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
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListImage> ListImages { get; set; }
    }
}
