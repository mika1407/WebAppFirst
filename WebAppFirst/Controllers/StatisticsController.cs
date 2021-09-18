using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppFirst.Models;
using WebAppFirst.ViewModels;

namespace WebAppFirst.Controllers
{
    public class StatisticsController : Controller
    {
        private northwindEntities db = new northwindEntities();
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategorySales()
        {
            string categoryNameList;
            string categorySalesList;
            List<CategorySalesClass> CategorySalesList = new List<CategorySalesClass>();

            var categorySalesData = from cs in db.Category_Sales_for_1997
                                    select cs;

            foreach (Category_Sales_for_1997 salesfor1997 in categorySalesData)
            {
                CategorySalesClass OneSalesRow = new CategorySalesClass();
                OneSalesRow.CategoryName = salesfor1997.CategoryName;
                OneSalesRow.CategorySales = (int)salesfor1997.CategorySales;
                //OneSalesRow.CategorySales = 11;
                CategorySalesList.Add(OneSalesRow);
            }

            categoryNameList = "'" + string.Join("','", CategorySalesList.Select(n => n.CategoryName).ToList()) + "'";
            categorySalesList = string.Join(",", CategorySalesList.Select(n => n.CategorySales).ToList());



            ViewBag.categoryName = categoryNameList;
            ViewBag.categorySales = categorySalesList;
            //ViewBag.categorySales = "1,3,4,2,45,65,43,2";

            return View();

        }
    }
}