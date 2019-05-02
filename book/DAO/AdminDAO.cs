using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.Models.Entities;

namespace book.DAO
{
    public class AdminDAO
    {
        private MyDBContext db;

        public AdminDAO()
        {
            db = new MyDBContext();
        }

        public int Login(string UserName, string Password)
        {
            var ret = db.Admins.Count(x => x.UserName == UserName && x.Password == Password);
            if (ret > 0)
                return 1;
            else
                return -1;
        }
    }
}