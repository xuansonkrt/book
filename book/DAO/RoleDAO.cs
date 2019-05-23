using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.Global;
using book.Models.Entities;

namespace book.DAO
{
    public class RoleDAO
    {
        private MyDBContext db;

        public RoleDAO()
        {
            db = new MyDBContext();
        }

        public List<Role> GetAll()
        {
            return db.Roles.ToList();
        }
    }
}