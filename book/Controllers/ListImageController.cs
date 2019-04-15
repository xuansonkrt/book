using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagementSystem.Models;


namespace BookManagementSystem.Controllers
{
    public class ListImageController : Controller
    {
        // GET: ListImage
        public ActionResult Index()
        {
            return View();
        }
        // tao list ListImage
        public ActionResult List()
        {
            List<ListImage> list = new List<ListImage>();
            for (int i = 0; i <= 10; i++)
            {
                ListImage ListImage = new ListImage();
                ListImage.ID = i;
                ListImage.ID_CuonSach = i + 2;
                ListImage.link = " link" + i;
                list.Add(ListImage);
            }
            return View(list);
        }
        //tao ListImage moi
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ListImage _ListImage)
        {
            return RedirectToAction("List");
        }
        // Sua ListImage duoc chon
        public ActionResult Edit(int id)
        {
            ListImage ListImage = new ListImage(id, 2, "link ");
            return View(ListImage);
        }
        [HttpPost]
        public ActionResult Edit(ListImage ListImage)
        {
            return RedirectToAction("List");
        }
        // chi tiet ListImage duoc chon
        public ActionResult Details(int id)
        {
            ListImage ListImage = new ListImage(id, 2, "link ");
            return View(ListImage);
        }
        [HttpPost]
        public ActionResult Details()
        {

            return RedirectToAction("List");
        }
        // xoa ListImage duoc chon   
        public ActionResult Delete(int id)
        {
            ListImage ListImage = new ListImage(id, 2, "link ");
            return View(ListImage);

        }
        [HttpPost]
        public ActionResult Delete(ListImage ListImage)
        {
            return RedirectToAction("List");
        }
    }
}