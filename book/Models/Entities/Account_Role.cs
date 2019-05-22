namespace book.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account_Role
    {
        public int ID { get; set; }

        public int? AccountID { get; set; }

        public int? RoleID { get; set; }

        public virtual Account Account { get; set; }

        public virtual Role Role { get; set; }
    }
}
