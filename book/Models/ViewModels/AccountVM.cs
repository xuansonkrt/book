using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book.Models.ViewModels
{
    public class AccountVM
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }


        public string Password { get; set; }


        public string Telephone { get; set; }


        public int? Gender { get; set; }

   
        public DateTime? CreatedDate { get; set; }


        public string DateOfBirth { get; set; }
        
        public string Address { get; set; }

        public int? Status { get; set; }

        public string Avatar { get; set; }

        public int RoleID { get; set; }
    }
}