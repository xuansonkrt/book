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
            var ret = db.Accounts.Count(x => x.UserName == UserName && x.Password == Password);
            if (ret > 0)
                return 1;
            else
                return -1;
        }

        public Account GetAdmin(string UserName, string Password)
        {
            using (var context = new MyDBContext())
            {
                var query = from ad in context.Accounts
                            where ad.UserName == UserName && ad.Password==Password
                            select ad;

                var admin =(Account) query.FirstOrDefault<Account>();
                return admin;

            };
        }
    }
}