namespace book.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImportDetail")]
    public partial class ImportDetail
    {
        public int ID { get; set; }

        public int? BookID { get; set; }

        public int? ImportID { get; set; }

        public int? Amount { get; set; }

        public decimal? Price { get; set; }

        public virtual Book Book { get; set; }

        public virtual Import Import { get; set; }
    }
}
