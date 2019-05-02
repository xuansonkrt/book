namespace book.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoiceDetail")]
    public partial class InvoiceDetail
    {
        public int ID { get; set; }

        public int ID_Book { get; set; }

        public int ID_Invoice { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public virtual Book Book { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
