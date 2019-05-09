using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.Models.Entities;
using System.Data.SqlClient;
using WebGrease.Css.Ast.Selectors;

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

        public Admin GetAdmin(string UserName, string Password)
        {
            using (var context = new MyDBContext())
            {
                var query = from ad in context.Admins
                    where ad.UserName == UserName && ad.Password==Password
                            select ad;

                var admin =(Admin) query.FirstOrDefault<Admin>();
                return admin;

            };
        }
    }
}