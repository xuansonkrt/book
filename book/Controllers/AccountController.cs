using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using book.DAO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using book.Models;
using PagedList;
using WebApplication1.Models;
using book.Models.Entities;
using book.Models.ViewModels;
using System.Web.Script.Serialization;
using book.Extensions;
using Newtonsoft.Json;

namespace book.Controllers
{
   
    public class AccountController : Controller
    {
        

        public AccountController()
        {
        }
        AdminDAO dao = new AdminDAO();
        
        public ActionResult Login()
        {
            //  ViewBag.confirm = "begin";
            return View("~/Views/Admin/Login.cshtml");
        }
        [HttpPost]
        public JsonResult Login(Account _admin)
        {

            int ret = -1;
            Account admin = dao.GetAdmin(_admin.UserName, _admin.Password);
            if (admin != null)
            {
                RoleDAO roleDao = new RoleDAO();
                Account_Role accountRole = roleDao.GetByAccount(admin.ID);
                if (accountRole.RoleID == VARIABLE_ROLE.ADMIN)
                {
                    Session["isAdmin"] = true;
                    ret = 1;
                }
                else
                {
                    Session["isAdmin"] = false;
                    ret = 2;
                }
                    

                Session["accountLogin"] = admin;
                Session["username"] = admin.UserName;
                Session["name"] = admin.Name;
                Session["acc"] = admin.UserName;
                Session["avatar"] = admin.Avatar;
                Session["ID"] = admin.ID;
            }
            return Json(new
            {
                ret //ok
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SignUp()
        {
            return View("~/Views/Admin/SignUp.cshtml");
        }

        public JsonResult Register(string username, string email, string password)
        {
            AccountDAO dao = new AccountDAO();
            if (dao.isExist(username))
            {
                return Json(new
                {
                    ret=-100 //ok
                }, JsonRequestBehavior.AllowGet);
            }

            Account account= new Account();
            account.UserName = username;
            account.Email = email;
            account.Password = password;
            account.CreatedDate= DateTime.Now;
            account.Status = 1;
            account.Avatar = "/UploadedFiles/noimage.png";
            account.Name = "Vô danh";
            int ret = dao.Insert(account);
            return Json(new
            {
                ret=1
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult Index(int? page = 1, int pageSize = 10)
        {
            int pageNumber = page ?? 1;
            AccountDAO dao = new AccountDAO();
            string _roleid = Request.QueryString["roleId"];
            string _keyword = Request.QueryString["keyWord"];
            int roleId = 0;
            string keyword = "";
            if(_roleid!=null)
                roleId = Int32.Parse(_roleid);
            if (_keyword != null)
                keyword = _keyword;
            var list = dao.GetAllSearh(roleId, keyword);
            var listTmp = list.ToPagedList(pageNumber, pageSize);
            List<AccountVM> listAcc = new List<AccountVM>();
            foreach (var item in listTmp)
            {
                AccountVM vm = new AccountVM();
                vm.ID = item.ID;
                vm.Name = item.Name;
                vm.UserName = item.UserName;
                vm.Gender = item.Gender;
                vm.Address = item.Address;
                vm.Email = item.Email;
                vm.Telephone = item.Telephone;
                if(item.DateOfBirth!=null)
                    vm.DateOfBirth = ((DateTime)item.DateOfBirth).ToString("dd/MM/yyyy");
                else
                {
                    vm.DateOfBirth = "";
                }
                vm.RoleID = dao.GetRoleId(item.ID);

                listAcc.Add(vm);
            }
            IPagedList<AccountVM> pageBook = new StaticPagedList<AccountVM>(listAcc
                , pageNumber, pageSize, list.Count());

            RoleDAO roleDao = new RoleDAO();
            var listRole = roleDao.GetAll();
            ViewBag.listRole = listRole;
            return View(pageBook);
        }


        public JsonResult ChangeRole(string roleId, string accountId)
        {
            AccountDAO dao = new AccountDAO();
            int ret = dao.ChangeoRole(Int32.Parse(roleId), Int32.Parse(accountId));

            return Json(new
            {
                ret
            }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete(string accountId)
        {
            AccountDAO dao = new AccountDAO();
            int ret= dao.Delete(Int32.Parse(accountId));
            return Json(new
            {
                ret
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAccount(string accountId)
        {
            AccountDAO dao = new AccountDAO();
            Account account = dao.FindOne(Int32.Parse(accountId));
            int ret = account == null ? -1 : 1;
            AccountVM vm = new AccountVM();
            vm.ID = account.ID;
            vm.Name = account.Name;
            vm.UserName = account.UserName;
            vm.Gender = account.Gender;
            vm.Address = account.Address;
            vm.Email = account.Email;
            vm.Telephone = account.Telephone;
            if(account.DateOfBirth!=null)
                vm.DateOfBirth = ((DateTime)account.DateOfBirth).ToString("dd/MM/yyyy");
            else
            {
                vm.DateOfBirth = "";
            }
            vm.RoleID = dao.GetRoleId(account.ID);
            vm.Avatar = account.Avatar;
            var obj = vm;//JsonConvert.SerializeObject(vm);
            return Json(new
            {
                ret,
                obj
            }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(AccountVM accountVm)
        {

            Account account = new Account();
            account.ID = accountVm.ID;
            account.Name = accountVm.Name;
            account.Email = accountVm.Email;
            account.Telephone = accountVm.Telephone;
            account.Gender = accountVm.Gender;
            account.Avatar = accountVm.Avatar;
            account.Address = accountVm.Address;
            account.DateOfBirth = DateTime.ParseExact(accountVm.DateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int ret;
            AccountDAO dao = new AccountDAO();
            ret = dao.Update(account);
            return Json(new
            {
               ret
               // obj
            }, JsonRequestBehavior.AllowGet);
        }


    }
}