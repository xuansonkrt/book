using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.DAO;
using book.Global;
using book.Models.ViewModels;

namespace book.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            ReportDAO dao = new ReportDAO();
            int TotalOrderOfWeek = dao.TotalOrderOfWeek();
            decimal TotalPriceOfWeek = dao.TotalPriceOfWeek();
            var list = dao.ProfitInWeek();
            ChartVM chart = new ChartVM();
            for (int i = 0; i < list.Count; i++)
            {
                ItemChartVM vm = new ItemChartVM();
                vm.DATA = list[i].DATA;
                vm.LABEL = MyFunction.convert2String(list[i].DAY);
               // list[i].LABEL = MyFunction.convert2String(list[i].DAY);
               chart.list.Add(vm);
            }
            ViewBag.TotalOrderOfWeek = TotalOrderOfWeek;
            ViewBag.TotalPriceOfWeek = TotalPriceOfWeek;
            
            ViewBag.ProfitInWeek = chart;
            return View();
        }
    }
}