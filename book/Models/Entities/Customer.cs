using System.ComponentModel;

namespace book.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Carts = new HashSet<Cart>();
            Rates = new HashSet<Rate>();
            Invoices = new HashSet<Invoice>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Họ và tên")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [DisplayName("Số điện thoại")]
        public int Telephone { get; set; }

        [DisplayName("Giới tính")]
        public int? Gender { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày tham gia")]
        public DateTime? join_Date { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
