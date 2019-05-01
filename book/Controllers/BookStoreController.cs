using book.Models.ViewModels;
using book.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.Models.Entities;

namespace Web_BookStore1.Controllers
{
    public class BookStoreController : Controller
    {
        // GET: BookStore
        public ActionResult Index()
        {
            HomeVM vm = new HomeVM();
            //List<TheLoai> listtheloai = new List<TheLoai>();
            //listtheloai.Add(new TheLoai(1, "VĂN HỌC VIỆT NAM"));
            //listtheloai.Add(new TheLoai(2, "VĂN HỌC NƯỚC NGOÀI"));
            //listtheloai.Add(new TheLoai(3, "TIỂU THUYẾT"));
            //listtheloai.Add(new TheLoai(4, "SÁCH KỸ NĂNG"));
            //listtheloai.Add(new TheLoai(5, "SÁCH SONG NGỮ"));
            //listtheloai.Add(new TheLoai(6, "SÁCH THIẾU NHI"));

            //List<NhaXuatBan> listnxb = new List<NhaXuatBan>();
            //listnxb.Add(new NhaXuatBan(1, "NHÃ NAM"));
            //listnxb.Add(new NhaXuatBan(2, "SKYBOOK"));
            //listnxb.Add(new NhaXuatBan(3, "NHÀ XUẤT BẢN TRẺ"));
            //listnxb.Add(new NhaXuatBan(4, "THÁI HÀ"));
            //listnxb.Add(new NhaXuatBan(5, "NHÀ XUẤT BẢN GIÁO DỤC"));

            //List<CuonSach> listcuonsach = new List<CuonSach>();
            //for (int i = 0; i <= 10; i++)
            //{
            //    CuonSach CuonSach = new CuonSach();
            //    CuonSach.Id = i;
            //    CuonSach.Name = " CuonSach " + i;
            //    CuonSach.GiaTien = 200 * i;
            //    CuonSach.GioiThieu = " gioi thieu " + i;
            //    CuonSach.TacGia = "Tac gia " + i;
            //    CuonSach.Id_NXB = i + 10;
            //    CuonSach.ID_TheLoai = i + 20;
            //    CuonSach.SoLuong = i + 3;
            //    CuonSach.MainImage = "/Content/images/home/VD2.PNG";
            //    listcuonsach.Add(CuonSach);
            //}

            //var vm = new HomeVM
            //{
            //    ListTheLoai = listtheloai,
            //    ListCuonSach = listcuonsach
            //};
            //ViewBag.listtheloai = listtheloai;
            //ViewBag.listnxb = listnxb;
            return View(vm);
        }
       
        public ActionResult SachBanChay()
        {
            return View();
        }
        public ActionResult TieuThuyet()
        {
            return View();
        }

        public ActionResult TheLoai(string id)
        {
            //List<TheLoai> listtheloai = new List<TheLoai>();
            //listtheloai.Add(new TheLoai(1, "VĂN HỌC VIỆT NAM"));
            //listtheloai.Add(new TheLoai(2, "VĂN HỌC NƯỚC NGOÀI"));
            //listtheloai.Add(new TheLoai(3, "TIỂU THUYẾT"));
            //listtheloai.Add(new TheLoai(4, "SÁCH KỸ NĂNG"));
            //listtheloai.Add(new TheLoai(5, "SÁCH SONG NGỮ"));
            //listtheloai.Add(new TheLoai(6, "SÁCH THIẾU NHI"));

            //List<NhaXuatBan> listnxb = new List<NhaXuatBan>();
            //listnxb.Add(new NhaXuatBan(1, "NHÃ NAM"));
            //listnxb.Add(new NhaXuatBan(2, "SKYBOOK"));
            //listnxb.Add(new NhaXuatBan(3, "NHÀ XUẤT BẢN TRẺ"));
            //listnxb.Add(new NhaXuatBan(4, "THÁI HÀ"));
            //listnxb.Add(new NhaXuatBan(5, "NHÀ XUẤT BẢN GIÁO DỤC"));

            //List<CuonSach> listcuonsach = new List<CuonSach>();
            //for (int i = 0; i <= 10; i++)
            //{
            //    CuonSach CuonSach = new CuonSach();
            //    CuonSach.Id = i;
            //    CuonSach.Name = " CuonSach " + i;
            //    CuonSach.GiaTien = 200 * i;
            //    CuonSach.GioiThieu = " gioi thieu " + i;
            //    CuonSach.TacGia = "Tac gia " + i;
            //    CuonSach.Id_NXB = i + 10;
            //    CuonSach.ID_TheLoai = i + 20;
            //    CuonSach.SoLuong = i + 3;
            //    CuonSach.MainImage = "/Content/images/home/VD2.PNG";
            //    listcuonsach.Add(CuonSach);
            //}

            var vm = new HomeVM();
            //{
            //    ListTheLoai = listtheloai,
            //    ListCuonSach = listcuonsach
            //};
            //ViewBag.listtheloai = listtheloai;
            //ViewBag.listnxb = listnxb;
            return View("~/Views/BookStore/Index.cshtml",vm);
        }


        public ActionResult NXB(string id)
        {
            //List<TheLoai> listtheloai = new List<TheLoai>();
            //listtheloai.Add(new TheLoai(1, "VĂN HỌC VIỆT NAM"));
            //listtheloai.Add(new TheLoai(2, "VĂN HỌC NƯỚC NGOÀI"));
            //listtheloai.Add(new TheLoai(3, "TIỂU THUYẾT"));
            //listtheloai.Add(new TheLoai(4, "SÁCH KỸ NĂNG"));
            //listtheloai.Add(new TheLoai(5, "SÁCH SONG NGỮ"));
            //listtheloai.Add(new TheLoai(6, "SÁCH THIẾU NHI"));

            //List<NhaXuatBan> listnxb = new List<NhaXuatBan>();
            //listnxb.Add(new NhaXuatBan(1, "NHÃ NAM"));
            //listnxb.Add(new NhaXuatBan(2, "SKYBOOK"));
            //listnxb.Add(new NhaXuatBan(3, "NHÀ XUẤT BẢN TRẺ"));
            //listnxb.Add(new NhaXuatBan(4, "THÁI HÀ"));
            //listnxb.Add(new NhaXuatBan(5, "NHÀ XUẤT BẢN GIÁO DỤC"));

            //List<CuonSach> listcuonsach = new List<CuonSach>();
            //for (int i = 0; i <= 10; i++)
            //{
            //    CuonSach CuonSach = new CuonSach();
            //    CuonSach.Id = i;
            //    CuonSach.Name = " CuonSach " + i;
            //    CuonSach.GiaTien = 200 * i;
            //    CuonSach.GioiThieu = " gioi thieu " + i;
            //    CuonSach.TacGia = "Tac gia " + i;
            //    CuonSach.Id_NXB = i + 10;
            //    CuonSach.ID_TheLoai = i + 20;
            //    CuonSach.SoLuong = i + 3;
            //    CuonSach.MainImage = "/Content/images/home/VD2.PNG";
            //    listcuonsach.Add(CuonSach);
            //}

         var vm = new HomeVM();
            //{
            //    ListTheLoai = listtheloai,
            //    ListCuonSach = listcuonsach
            //};
            //ViewBag.listtheloai = listtheloai;
            //ViewBag.listnxb = listnxb;
            return View("~/Views/BookStore/Index.cshtml", vm);
        }

        public ActionResult Detail(string id)
        {
            //List<TheLoai> listtheloai = new List<TheLoai>();
            //listtheloai.Add(new TheLoai(1, "VĂN HỌC VIỆT NAM"));
            //listtheloai.Add(new TheLoai(2, "VĂN HỌC NƯỚC NGOÀI"));
            //listtheloai.Add(new TheLoai(3, "TIỂU THUYẾT"));
            //listtheloai.Add(new TheLoai(4, "SÁCH KỸ NĂNG"));
            //listtheloai.Add(new TheLoai(5, "SÁCH SONG NGỮ"));
            //listtheloai.Add(new TheLoai(6, "SÁCH THIẾU NHI"));

            //List<NhaXuatBan> listnxb = new List<NhaXuatBan>();
            //listnxb.Add(new NhaXuatBan(1, "NHÃ NAM"));
            //listnxb.Add(new NhaXuatBan(2, "SKYBOOK"));
            //listnxb.Add(new NhaXuatBan(3, "NHÀ XUẤT BẢN TRẺ"));
            //listnxb.Add(new NhaXuatBan(4, "THÁI HÀ"));
            //listnxb.Add(new NhaXuatBan(5, "NHÀ XUẤT BẢN GIÁO DỤC"));

            //int i = Int32.Parse(id);
            Book cuonSach = new Book();
            //cuonSach.Id = i;
            //cuonSach.Name = "Nhà giả kim";
            //cuonSach.GiaTien = 200 * i;
            //cuonSach.GioiThieu = "Nhà giả kim của Paulo Coelho như một câu chuyện cổ tích giản dị, nhân ái, giàu chất thơ, thấm đẫm những minh triết huyền bí của phương Đông. Trong lần xuất bản đầu tiên tại Brazil vào năm 1988, sách chỉ bán được 900 bản. Nhưng, với số phận đặc biệt của cuốn sách dành cho toàn nhân loại, vượt ra ngoài biên giới quốc gia, Nhà giả kim đã làm rung động hàng triệu tâm hồn, trở thành một trong những cuốn sách bán chạy nhất mọi thời đại, và có thể làm thay đổi cuộc đời người đọc.";
            //cuonSach.TacGia = "Tac gia " + i;
            //cuonSach.Id_NXB = i + 10;
            //cuonSach.ID_TheLoai = i + 20;
            //cuonSach.SoLuong = i + 3;
            //cuonSach.MainImage = "/Content/images/home/VD2.PNG";
            //ViewBag.listtheloai = listtheloai;
            //ViewBag.listnxb = listnxb;
            return View(cuonSach);
        }



    }
}