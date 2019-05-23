using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using book.Extensions;
using book.Models.Entities;

namespace book.DAO
{
    public class AccountDAO
    {
        private MyDBContext db;

        public AccountDAO()
        {
            db = new MyDBContext();
        }

        public IEnumerable<Account> GetAllSearh(int RoleId, string keyWord)
        {
            var list = db.Accounts.SqlQuery("EXEC Account_GetAllSearch @roleId, @keyWord",
                new SqlParameter("roleId", RoleId), new SqlParameter("keyWord", keyWord)).ToList();
            return list;
        }

        public int GetRoleId(int AccountId)
        {
            var item =db.Database.SqlQuery<int>("EXEC Account_GetRoleID @AccountId",
                new SqlParameter("AccountId", AccountId)).FirstOrDefault();
            return item;
        }

        public int ChangeoRole(int roleId, int accountId)
        {
           return  db.Database.ExecuteSqlCommand("EXEC Account_ChangeRole @accountid, @roleid",
                new SqlParameter("accountid", accountId), new SqlParameter("roleId", roleId));
        }

        public int Delete(int accountId)
        {
            Account account = db.Accounts.Find(accountId);
            account.Status = 0;
            return db.SaveChanges();
        }

        public bool isExist(string username)
        {
            var item = db.Accounts.Where(x => x.UserName == username).FirstOrDefault();
            return (item != null);
        }

        public int Insert(Account account)
        {
            int ret;
            try
            {
                db.Accounts.Add(account);
                ret = db.SaveChanges();
                if (ret > 0)
                {
                    Account_Role accountRole = new Account_Role();
                    accountRole.AccountID = account.ID;
                    accountRole.RoleID = VARIABLE_ROLE.CUSTOMER;
                    db.Account_Role.Add(accountRole);
                    ret = db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return ret;
        }

        public Account FindOne(int id)
        {
            return db.Accounts.Find(id);
        }

        public int Update(Account _account)
        {
            Account account = db.Accounts.Find(_account.ID);
            if (account == null)
                return -1;

            if (account.Avatar!=null)
            {
                string server = HttpRuntime.AppDomainAppPath.ToString();
                ///  string filePath = Path.Combine(server, book.MainImage);
                var arr = account.Avatar.Split('/');
                string filePath = server + arr[1] + "\\" + arr[2];
                System.IO.File.Delete(filePath);
            }

            account.Name = _account.Name;
            account.Email = _account.Email;
            account.Telephone = _account.Telephone;
            account.Address = _account.Address;
            account.Avatar = _account.Avatar;
            account.Gender = _account.Gender;
            account.DateOfBirth = _account.DateOfBirth;
            return db.SaveChanges();
        }
    }
}