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
using SmartHome.Models;
using System.Data.SqlClient;

namespace SmartHome.Controllers
{
    public class HouseAreasAPIController : ApiController
    {
        private SmartHomeEntities3 db = new SmartHomeEntities3();

        // GET: api/HouseAreasAPI
        public IQueryable<HouseArea> GetHouseAreas()
        {
            return db.HouseAreas;
        }

        public IQueryable<HouseArea> GetHouseAreasId(int id)
        {
            List<HouseArea> houseAreas = new List<HouseArea>();
            var con = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartHome;Integrated Security=True;";
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "SELECT * FROM HouseArea"; //SELECT Id FROM HouseArea
                SqlCommand myCommand = new SqlCommand(oString, myConnection);

                myConnection.Open();
                using (SqlDataReader oReader = myCommand.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        houseAreas.Add(new HouseArea { Id = Convert.ToInt16(oReader["Id"]), Name = oReader["Name"].ToString() });
                    }
                    myConnection.Close();
                }
            }
            return houseAreas.AsQueryable();
        }
        // GET: api/HouseAreasAPI/5
        [ResponseType(typeof(HouseArea))]
        public async Task<IHttpActionResult> GetHouseArea(int id)
        {
            HouseArea houseArea = await db.HouseAreas.FindAsync(id);
            if (houseArea == null)
            {
                return NotFound();
            }

            return Ok(houseArea);
        }

        // PUT: api/HouseAreasAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHouseArea(int id, HouseArea houseArea)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostHouseArea(HouseArea houseArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HouseAreas.Add(houseArea);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = houseArea.Id }, houseArea);
        }

        // DELETE: api/HouseAreasAPI/5
        [ResponseType(typeof(HouseArea))]
        public async Task<IHttpActionResult> DeleteHouseArea(int id)
        {
            HouseArea houseArea = await db.HouseAreas.FindAsync(id);
            if (houseArea == null)
            {
                return NotFound();
            }

            db.HouseAreas.Remove(houseArea);
            await db.SaveChangesAsync();

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