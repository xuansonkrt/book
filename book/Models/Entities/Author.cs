using System.ComponentModel;

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

        [DisplayName("Tên tác giả")]
        [StringLength(100)]
        public string Name { get; set; }

        [DisplayName("Ngày sinh")]
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Giới tính")]
        public int? Gender { get; set; }

        [DisplayName("Địa chỉ")]
        [StringLength(500)]
        public string Address { get; set; }

        [DisplayName("Email")]
        [StringLength(200)]
        public string Email { get; set; }

        [DisplayName("Giới thiệu")]
        [StringLength(4000)]
        public string Description { get; set; }

        [DisplayName("Avatar")]
        [StringLength(500)]
        public string Avatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WriteBook> WriteBooks { get; set; }
    }
}
