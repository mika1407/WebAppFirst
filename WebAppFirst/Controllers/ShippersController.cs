using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppFirst.Models;
using WebAppFirst.ViewModels;

namespace WebAppFirst.Controllers
{
    public class ShippersController : Controller
    {
        private northwindEntities db = new northwindEntities();

        // GET: Shippers
        public ActionResult Index()
        {
            var shippers = db.Shippers.Include(s => s.Region);
            return View(shippers.ToList());
        }

        public ActionResult Yritys()
        {
            List<Yritykset> model = new List<Yritykset>();

            try
            {
                List<Shippers> shippers = db.Shippers.OrderByDescending(Shippers => Shippers.CompanyName).ToList();

                foreach(Shippers shipper in shippers)
                {
                    Yritykset yri = new Yritykset();
                    yri.ShipperID = shipper.ShipperID;
                    yri.RegionID = shipper.RegionID;
                    yri.CompanyName = shipper.CompanyName;
                    yri.Phone = shipper.Phone;
                    yri.RegionDescription = shipper.Region.RegionDescription;

                    model.Add(yri);
                }
            }
            finally 
            {
                db.Dispose();
            }
            return View(model);
        }

        // GET: Shippers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null)
            {
                return HttpNotFound();
            }
            return View(shippers);
        }

        // GET: Shippers/Create
        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription");
            return View();
        }

        // POST: Shippers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipperID,RegionID,CompanyName,Phone")] Shippers shippers)
        {
            if (ModelState.IsValid)
            {
                db.Shippers.Add(shippers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", shippers.RegionID);
            return View(shippers);
        }

        // GET: Shippers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", shippers.RegionID);
            return View(shippers);
        }

        // POST: Shippers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipperID,RegionID,CompanyName,Phone")] Shippers shippers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", shippers.RegionID);
            return View(shippers);
        }

        // GET: Shippers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null)
            {
                return HttpNotFound();
            }
            return View(shippers);
        }

        // POST: Shippers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shippers shippers = db.Shippers.Find(id);
            db.Shippers.Remove(shippers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
