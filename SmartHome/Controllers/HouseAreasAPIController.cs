using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SmartHome.Models;

namespace SmartHome.Controllers
{
    public class HouseAreasAPIController : ApiController
    {
        private SmartHomeEntities2 db = new SmartHomeEntities2();

        // GET: api/HouseAreasAPI
        public IQueryable<HouseArea> GetHouseAreas()
        {
            return db.HouseAreas;
        }

        // GET: api/HouseAreasAPI/5
        [ResponseType(typeof(HouseArea))]
        public IHttpActionResult GetHouseArea(int id)
        {
            HouseArea houseArea = db.HouseAreas.Find(id);
            if (houseArea == null)
            {
                return NotFound();
            }

            return Ok(houseArea);
        }

        // PUT: api/HouseAreasAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHouseArea(int id, HouseArea houseArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != houseArea.Id)
            {
                return BadRequest();
            }

            db.Entry(houseArea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseAreaExists(id))
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

        // POST: api/HouseAreasAPI
        [ResponseType(typeof(HouseArea))]
        public IHttpActionResult PostHouseArea(HouseArea houseArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HouseAreas.Add(houseArea);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = houseArea.Id }, houseArea);
        }

        // DELETE: api/HouseAreasAPI/5
        [ResponseType(typeof(HouseArea))]
        public IHttpActionResult DeleteHouseArea(int id)
        {
            HouseArea houseArea = db.HouseAreas.Find(id);
            if (houseArea == null)
            {
                return NotFound();
            }

            db.HouseAreas.Remove(houseArea);
            db.SaveChanges();

            return Ok(houseArea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HouseAreaExists(int id)
        {
            return db.HouseAreas.Count(e => e.Id == id) > 0;
        }
    }
}