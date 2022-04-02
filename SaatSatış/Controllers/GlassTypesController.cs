using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using SaatSatış.DAL;

namespace SaatSatış.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GlassTypesController : Controller
    {
        private WatchContext db = new WatchContext();

        // GET: GlassTypes
        public ActionResult Index()
        {
            return View(db.GlassTypes.ToList());
        }

        // GET: GlassTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlassType glassType = db.GlassTypes.Find(id);
            if (glassType == null)
            {
                return HttpNotFound();
            }
            return View(glassType);
        }

        // GET: GlassTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GlassTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GlassTypeID,GlassTypeName")] GlassType glassType)
        {
            if (ModelState.IsValid)
            {
                db.GlassTypes.Add(glassType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glassType);
        }

        // GET: GlassTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlassType glassType = db.GlassTypes.Find(id);
            if (glassType == null)
            {
                return HttpNotFound();
            }
            return View(glassType);
        }

        // POST: GlassTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GlassTypeID,GlassTypeName")] GlassType glassType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glassType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glassType);
        }

        // GET: GlassTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlassType glassType = db.GlassTypes.Find(id);
            if (glassType == null)
            {
                return HttpNotFound();
            }
            return View(glassType);
        }

        // POST: GlassTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GlassType glassType = db.GlassTypes.Find(id);
            db.GlassTypes.Remove(glassType);
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
