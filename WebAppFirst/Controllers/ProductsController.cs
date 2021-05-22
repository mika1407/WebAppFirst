using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppFirst.Models;

namespace WebAppFirst.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            northwindEntities db = new northwindEntities();
            List<Products> model = db.Products.ToList();
            db.Dispose();

            return View(model);
        }
    }
}