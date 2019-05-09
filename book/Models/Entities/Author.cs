namespace book.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Author()
        {
            WriteBooks = new HashSet<WriteBook>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Giới tính")]
        public int? Gender { get; set; }

        [StringLength(500)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(4000)]
        [Display(Name = "Giới thiệu")]
        public string Description { get; set; }

        [StringLength(500)]
        public string Avatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WriteBook> WriteBooks { get; set; }
    }
}
