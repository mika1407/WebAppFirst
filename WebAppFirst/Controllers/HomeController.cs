using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Tietoa näistä sivuista. / Your application description page.";
            ViewBag.Herja = "Ole huolellinen, ettei tule virheitä!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Minun yhteystiedot. / Your contact page.";

            return View();
        }

        public ActionResult Map()
        {
            ViewBag.Message = "Saapumisohje / Map.";

            return View();
        }
    }
}