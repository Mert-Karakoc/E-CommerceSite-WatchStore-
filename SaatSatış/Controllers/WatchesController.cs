using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using SaatSatış.DAL;
using SaatSatış.Models;
using SaatSatış.Utility;

namespace SaatSatış.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WatchesController : Controller
    {
        private WatchContext db = new WatchContext();

        // GET: Watches
        public ActionResult Index()
        {
            List<WatchVM> watches = new List<WatchVM>();
            foreach (Watch watch in db.Watches)
            {
                WatchVM watchVM = new WatchVM();
                watchVM.Watch = watch;
                watchVM.Pictures = watch.Pictures;
                watches.Add(watchVM);
            }
            return View(watches.ToList());

        }

        // GET: Watches/Details/5
        public ActionResult Details(int? id)
        {
            WatchVM watchVm = new WatchVM();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = db.Watches.Find(id);
            watchVm.Watch = watch;
            watchVm.Pictures = db.Pictures.Where(p => p.WatchID == id).ToList();
            if (watch == null)
            {
                return HttpNotFound();
            }
            return View(watchVm);
        }

        // GET: Watches/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName");
            ViewBag.CaseShapeID = new SelectList(db.CaseShapes, "CaseShapeID", "CaseShapeName");
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName");
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderName");
            ViewBag.GlassTypeID = new SelectList(db.GlassTypes, "GlassTypeID", "GlassTypeName");
            ViewBag.StrapTypeID = new SelectList(db.StrapTypes, "StrapTypeID", "StrapTypeName");
            ViewBag.TechnologyID = new SelectList(db.Technologies, "TechnologyID", "TechnologyName");
            
            return View();
        }

        // POST: Watches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WatchID,BrandID,WatchModel,ColorID,CaseShapeID,GlassTypeID,StrapTypeID,TechnologyID,GenderID,Price")] Watch watch, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            if (ModelState.IsValid)
            {
                db.Watches.Add(watch);
                db.SaveChanges();
                int id = db.Watches.Where(w => w.WatchModel == watch.WatchModel).FirstOrDefault().WatchID;

                db.Pictures.Add(new Picture { WatchID = id, PictureName = file1.FileName });
                file1.SaveAs(Server.MapPath(@"\Images\" + file1.FileName));
                Image img = Image.FromFile(Server.MapPath(@"\Images\" + file1.FileName));
                Image imgThumb = img.GetThumbnailImage(150, 150, () => false, IntPtr.Zero);
                imgThumb.Save(Server.MapPath(@"~\Images\ThumbNails\" + file1.FileName));

                db.Pictures.Add(new Picture { WatchID = id, PictureName = file2.FileName });
                file2.SaveAs(Server.MapPath(@"\Images\" + file2.FileName));
                Image img2 = Image.FromFile(Server.MapPath(@"\Images\" + file2.FileName));
                Image imgThumb2 = img.GetThumbnailImage(150, 150, () => false, IntPtr.Zero);
                imgThumb.Save(Server.MapPath(@"~\Images\ThumbNails\" + file2.FileName));

                db.Pictures.Add(new Picture { WatchID = id, PictureName = file3.FileName });
                file3.SaveAs(Server.MapPath(@"\Images\" + file3.FileName));
                Image img3 = Image.FromFile(Server.MapPath(@"\Images\" + file2.FileName));
                Image imgThumb3 = img.GetThumbnailImage(150, 150, () => false, IntPtr.Zero);
                imgThumb.Save(Server.MapPath(@"~\Images\ThumbNails\" + file2.FileName));

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", watch.BrandID);
            ViewBag.CaseShapeID = new SelectList(db.CaseShapes, "CaseShapeID", "CaseShapeName", watch.CaseShapeID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", watch.ColorID);
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderName", watch.GenderID);
            ViewBag.GlassTypeID = new SelectList(db.GlassTypes, "GlassTypeID", "GlassTypeName", watch.GlassTypeID);
            ViewBag.StrapTypeID = new SelectList(db.StrapTypes, "StrapTypeID", "StrapTypeName", watch.StrapTypeID);
            ViewBag.TechnologyID = new SelectList(db.Technologies, "TechnologyID", "TechnologyName", watch.TechnologyID);
            return View(watch);
        }

        // GET: Watches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = db.Watches.Find(id);
            if (watch == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", watch.BrandID);
            ViewBag.CaseShapeID = new SelectList(db.CaseShapes, "CaseShapeID", "CaseShapeName", watch.CaseShapeID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", watch.ColorID);
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderName", watch.GenderID);
            ViewBag.GlassTypeID = new SelectList(db.GlassTypes, "GlassTypeID", "GlassTypeName", watch.GlassTypeID);
            ViewBag.StrapTypeID = new SelectList(db.StrapTypes, "StrapTypeID", "StrapTypeName", watch.StrapTypeID);
            ViewBag.TechnologyID = new SelectList(db.Technologies, "TechnologyID", "TechnologyName", watch.TechnologyID);
            return View(watch);
        }

        // POST: Watches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WatchID,BrandID,WatchModel,ColorID,CaseShapeID,GlassTypeID,StrapTypeID,TechnologyID,GenderID,Price")] Watch watch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(watch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", watch.BrandID);
            ViewBag.CaseShapeID = new SelectList(db.CaseShapes, "CaseShapeID", "CaseShapeName", watch.CaseShapeID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", watch.ColorID);
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderName", watch.GenderID);
            ViewBag.GlassTypeID = new SelectList(db.GlassTypes, "GlassTypeID", "GlassTypeName", watch.GlassTypeID);
            ViewBag.StrapTypeID = new SelectList(db.StrapTypes, "StrapTypeID", "StrapTypeName", watch.StrapTypeID);
            ViewBag.TechnologyID = new SelectList(db.Technologies, "TechnologyID", "TechnologyName", watch.TechnologyID);
            return View(watch);
        }

        // GET: Watches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = db.Watches.Find(id);
            if (watch == null)
            {
                return HttpNotFound();
            }
            return View(watch);
        }

        // POST: Watches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Watch watch = db.Watches.Find(id);
            db.Watches.Remove(watch);
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
