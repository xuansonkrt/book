namespace book.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CartDetail")]
    public partial class CartDetail
    {
      
        [Key]
        [Column(Order = 0)]
        public int ID_Book { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Cart { get; set; }

        public int? Quantity { get; set; }

        public virtual Book Book { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
