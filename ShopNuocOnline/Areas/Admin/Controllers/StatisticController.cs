using Microsoft.AspNet.Identity;
using OfficeOpenXml;
using ShopNuocOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocOnline.Areas.Admin.Controllers
{
    public class StatisticController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Statistic
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order(DateTime from, DateTime to)
        {
            List<Order> orders = db.Orders.Where(x => DbFunctions.TruncateTime(x.OrderDate) >= from.Date && DbFunctions.TruncateTime(x.OrderDate) <= to.Date).ToList();
            ViewBag.from = from;
            ViewBag.to = to;
            return View(orders);
        }

        [HttpGet]
        public void DownloadExcelStatisticOrder(DateTime from, DateTime to)
        {
            List<Order> orders = db.Orders.Where(x => DbFunctions.TruncateTime(x.OrderDate) >= from.Date && DbFunctions.TruncateTime(x.OrderDate) <= to.Date).ToList();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A2"].Value = "Người lập";
            ws.Cells["B2"].Value = User.Identity.GetUserName();

            ws.Cells["A3"].Value = "Ngày lập";
            ws.Cells["B3"].Value = DateTime.Now.ToShortDateString();

            ws.Cells["A6"].Value = "Mã ĐH";
            ws.Cells["B6"].Value = "Ngày Đặt";
            ws.Cells["C6"].Value = "Thành Tiền";

            int rowStart = 7;
            foreach (var item in orders)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Id;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.OrderDate.ToString("dd/MM/yyyy");
                ws.Cells[string.Format("C{0}", rowStart)].Value = "$" + item.Total;
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Đơn đặt hàng.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }

        public ActionResult Product(DateTime from, DateTime to)
        {
            List<Order> orders = db.Orders.Where(x => DbFunctions.TruncateTime(x.OrderDate) >= from.Date && DbFunctions.TruncateTime(x.OrderDate) <= to.Date).ToList();
            ViewBag.from = from;
            ViewBag.to = to;
            return View(orders);
        }
    }
}