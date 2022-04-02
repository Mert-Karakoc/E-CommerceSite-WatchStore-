using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Models;
using SaatSatış.DAL;
using SaatSatış.Models;

namespace SaatSatış.Controllers
{
    public class WatchesServiceController : ApiController
    {
        private WatchContext db = new WatchContext();

        // GET: api/WatchesService
        public IQueryable<Watch> GetWatches()
        {
            return db.Watches;
        }

        // GET: api/WatchesService/5
        [ResponseType(typeof(Watch))]
        public IHttpActionResult GetWatch(int id)
        {
            Watch watch = db.Watches.Find(id);
            if (watch == null)
            {
                return NotFound();
            }

            return Ok(watch);
        }

        // PUT: api/WatchesService/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWatch(int id, Watch watch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != watch.WatchID)
            {
                return BadRequest();
            }

            db.Entry(watch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WatchesService
        [ResponseType(typeof(Watch))]
        public IHttpActionResult PostWatch(Watch watch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Watches.Add(watch);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = watch.WatchID }, watch);
        }

        // DELETE: api/WatchesService/5
        [ResponseType(typeof(Watch))]
        public IHttpActionResult DeleteWatch(int id)
        {
            Watch watch = db.Watches.Find(id);
            if (watch == null)
            {
                return NotFound();
            }

            db.Watches.Remove(watch);
            db.SaveChanges();

            return Ok(watch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WatchExists(int id)
        {
            return db.Watches.Count(e => e.WatchID == id) > 0;
        }
    }
}