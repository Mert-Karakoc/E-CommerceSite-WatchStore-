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
    public class StrapTypesController : Controller
    {
        private WatchContext db = new WatchContext();

        // GET: StrapTypes
        public ActionResult Index()
        {
            return View(db.StrapTypes.ToList());
        }

        // GET: StrapTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrapType strapType = db.StrapTypes.Find(id);
            if (strapType == null)
            {
                return HttpNotFound();
            }
            return View(strapType);
        }

        // GET: StrapTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StrapTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StrapTypeID,StrapTypeName")] StrapType strapType)
        {
            if (ModelState.IsValid)
            {
                db.StrapTypes.Add(strapType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(strapType);
        }

        // GET: StrapTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrapType strapType = db.StrapTypes.Find(id);
            if (strapType == null)
            {
                return HttpNotFound();
            }
            return View(strapType);
        }

        // POST: StrapTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StrapTypeID,StrapTypeName")] StrapType strapType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strapType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(strapType);
        }

        // GET: StrapTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrapType strapType = db.StrapTypes.Find(id);
            if (strapType == null)
            {
                return HttpNotFound();
            }
            return View(strapType);
        }

        // POST: StrapTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StrapType strapType = db.StrapTypes.Find(id);
            db.StrapTypes.Remove(strapType);
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
