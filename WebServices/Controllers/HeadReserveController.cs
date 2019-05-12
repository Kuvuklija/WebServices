using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebServices.Concrete;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class HeadReserveController : Controller
    {
        private EFContext db = new EFContext();

        // GET: HeadReserve
        public ActionResult Index()
        {
            return View(db.HeadReserve.ToList());
        }

        // GET: HeadReserve/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadReserve headReserve = db.HeadReserve.Find(id);
            if (headReserve == null)
            {
                return HttpNotFound();
            }
            return View(headReserve);
        }

        // GET: HeadReserve/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeadReserve/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Location,Document,Result,Artikul,Batch,DocumentRow")] HeadReserve headReserve)
        {
            if (ModelState.IsValid)
            {
                db.HeadReserve.Add(headReserve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(headReserve);
        }

        // GET: HeadReserve/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadReserve headReserve = db.HeadReserve.Find(id);
            if (headReserve == null)
            {
                return HttpNotFound();
            }
            return View(headReserve);
        }

        // POST: HeadReserve/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Location,Document,Result,Artikul,Batch,DocumentRow")] HeadReserve headReserve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(headReserve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(headReserve);
        }

        // GET: HeadReserve/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadReserve headReserve = db.HeadReserve.Find(id);
            if (headReserve == null)
            {
                return HttpNotFound();
            }
            return View(headReserve);
        }

        // POST: HeadReserve/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            HeadReserve headReserve = db.HeadReserve.Find(id);
            db.HeadReserve.Remove(headReserve);
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
