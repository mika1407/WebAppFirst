using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppFirst.Models;

namespace WebAppFirst.Controllers
{
    public class ShippersController : Controller
    {
        // GET: Shippers
        northwindEntities db = new northwindEntities();
        public ActionResult Index()
        {
            List<Shippers> model = db.Shippers.ToList();
            return View(model);
        }
    }
}