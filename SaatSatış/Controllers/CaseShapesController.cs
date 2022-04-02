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
    public class CaseShapesController : Controller
    {
        private WatchContext db = new WatchContext();

        // GET: CaseShapes
        public ActionResult Index()
        {
            return View(db.CaseShapes.ToList());
        }

        // GET: CaseShapes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseShape caseShape = db.CaseShapes.Find(id);
            if (caseShape == null)
            {
                return HttpNotFound();
            }
            return View(caseShape);
        }

        // GET: CaseShapes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseShapes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseShapeID,CaseShapeName")] CaseShape caseShape)
        {
            if (ModelState.IsValid)
            {
                db.CaseShapes.Add(caseShape);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caseShape);
        }

        // GET: CaseShapes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseShape caseShape = db.CaseShapes.Find(id);
            if (caseShape == null)
            {
                return HttpNotFound();
            }
            return View(caseShape);
        }

        // POST: CaseShapes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseShapeID,CaseShapeName")] CaseShape caseShape)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseShape).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caseShape);
        }

        // GET: CaseShapes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseShape caseShape = db.CaseShapes.Find(id);
            if (caseShape == null)
            {
                return HttpNotFound();
            }
            return View(caseShape);
        }

        // POST: CaseShapes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseShape caseShape = db.CaseShapes.Find(id);
            db.CaseShapes.Remove(caseShape);
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
