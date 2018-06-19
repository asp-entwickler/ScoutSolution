using ScoutAPI.Context;
using ScoutAPI.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ScoutAPI.Source;
using System;
using System.Reflection;

namespace ScoutAPI.Controllers
{
	public class AdvertsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Adverts
        public IQueryable<Advert> GetAdverts(string sortby = "", string order = "")
        {
			IQueryable<Advert> result;

			var sortOrder = true;
			Type advType = typeof(Advert);

			PropertyInfo myPropInfo = advType.GetProperty(sortby);
			if (myPropInfo != null)
			{
				if (!string.IsNullOrEmpty(order))
					sortOrder = order == "desc" ? false : true;

				result = db.Adverts.AsQueryable().OrderByPropertyName(sortby, sortOrder);
			}
			else
			{
				result = db.Adverts;
			}

			return result;

		}

        // GET: api/Adverts/5
        [ResponseType(typeof(Advert))]
        public async Task<IHttpActionResult> GetAdvert(int id)
        {
            Advert advert = await db.Adverts.FindAsync(id);
            if (advert == null)
            {
                return NotFound();
            }

            return Ok(advert);
        }

        // PUT: api/Adverts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdvert(int id, Advert advert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != advert.Id)
            {
                return BadRequest();
            }

            db.Entry(advert).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertExists(id))
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

        // POST: api/Adverts
        [ResponseType(typeof(Advert))]
        public async Task<IHttpActionResult> PostAdvert(Advert advert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adverts.Add(advert);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = advert.Id }, advert);
        }

        // DELETE: api/Adverts/5
        [ResponseType(typeof(Advert))]
        public async Task<IHttpActionResult> DeleteAdvert(int id)
        {
            Advert advert = await db.Adverts.FindAsync(id);
            if (advert == null)
            {
                return NotFound();
            }

            db.Adverts.Remove(advert);
            await db.SaveChangesAsync();

            return Ok(advert);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdvertExists(int id)
        {
            return db.Adverts.Count(e => e.Id == id) > 0;
        }
    }
}