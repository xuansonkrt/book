﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.DAO;
using book.Models.Entities;
using book.Models.ViewModels;
using PagedList;

namespace book.Controllers
{
    public class InvoiceController : Controller
    {
        MyDBContext db = new MyDBContext();
        InvoiceDAO dao = new InvoiceDAO();
        // GET: Invoice
        public ActionResult Index(int? page = 1, int pageSize = 10)
        {
            if ((Session["username"] == null))
            {
                return Redirect("/Admin/Login");
            }
            int pageNumber = page ?? 1;

            InvoiceStatusDAO invoiceStatusDao = new InvoiceStatusDAO();
            List<InvoiceStatu> invoiceStatus = invoiceStatusDao.GetAll();
            SelectList statusList = new SelectList(invoiceStatus, "ID", "Name");
            ViewBag.InvoiceStatusList = statusList;
            ViewBag.InvoiceStatusList2 = invoiceStatus;
            // var list = dao.GetAll();
            var list = dao.GetAll2().ToPagedList(pageNumber, pageSize);
            //var list = (from l in db.Categories
            //            select l).OrderBy(x => x.Name);
            return View(list);
        }

        public JsonResult ChangeStatus(Invoice _invoice)
        {
            InvoiceDAO dao = new InvoiceDAO();
            int ret = dao.Update(_invoice);
            return Json(new
            {
                ret
            },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(string id)
        {
            if (Session["username"] == null)
            {
                return Redirect("/Admin/Login");
            }
            InvoiceDAO dao = new InvoiceDAO();
            Invoice invoice = dao.GetByID(Int32.Parse(id));
            List<Item> list = new List<Item>();
            foreach (var item in invoice.InvoiceDetails)
            {
                Item temp = new Item();
                temp.id = item.ID;
                temp.amount =(int) item.Quantity;
                temp.price = (double)item.Price;
                temp.name = item.Book.Name;
                temp.mainImage = item.Book.MainImage;
                list.Add(temp);
            }

            Customer customer = new Customer();
            customer.Name = invoice.Customer.Name;
            customer.Address = invoice.Customer.Address;
            customer.Email = invoice.Customer.Email;
            customer.Telephone = invoice.Customer.Telephone;
            var vm = new InvoiceDetailVM
            {
                invoice = invoice,
                customer = customer,
                list = list
            };
            return View(vm);
        }

        public ActionResult Print(string id)
        {
            if (Session["username"] == null)
            {
                return Redirect("/Admin/Login");
            }
            InvoiceDAO dao = new InvoiceDAO();
            Invoice invoice = dao.GetByID(Int32.Parse(id));
            List<Item> list = new List<Item>();
            foreach (var item in invoice.InvoiceDetails)
            {
                Item temp = new Item();
                temp.id = item.ID;
                temp.amount = (int)item.Quantity;
                temp.price = (double)item.Price;
                temp.name = item.Book.Name;
                temp.mainImage = item.Book.MainImage;
                list.Add(temp);
            }

            Customer customer = new Customer();
            customer.Name = invoice.Customer.Name;
            customer.Address = invoice.Customer.Address;
            customer.Email = invoice.Customer.Email;
            customer.Telephone = invoice.Customer.Telephone;
            var vm = new InvoiceDetailVM
            {
                invoice = invoice,
                customer = customer,
                list = list
            };
            return View("~/Views/Invoice/print.cshtml",vm);
        }
    }
}