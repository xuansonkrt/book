namespace book.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListImage")]
    public partial class ListImage
    {
        public int ID_Book { get; set; }

        public int ID { get; set; }

        [StringLength(1000)]
        public string Link { get; set; }

        public virtual Book Book { get; set; }
    }
}
