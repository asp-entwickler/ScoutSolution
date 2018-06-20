using ScoutAPI.DAL;
using ScoutAPI.Models;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;


namespace ScoutAPI.Controllers
{
	public class AdvertsController : ApiController
    {

		private IAdvertRepository _advertRepository;

		public AdvertsController(IAdvertRepository advRepository)
		{
			_advertRepository = advRepository;
		}

		// GET: api/Adverts
		public IQueryable<Advert> GetAdverts(string sortby = "id", string order = "")
        {
			IQueryable<Advert> result;

			var sortOrder = true;
			Type advType = typeof(Advert);

			PropertyInfo myPropInfo = advType.GetProperty(sortby);
			if (myPropInfo != null)
			{
				if (!string.IsNullOrEmpty(order))
					sortOrder = order == "desc" ? false : true;

				result = _advertRepository.GetAdverts().AsQueryable().OrderByPropertyName(sortby, sortOrder);
			}
			else
			{
				result = _advertRepository.GetAdverts().AsQueryable().OrderByPropertyName("id", true);
			}

			return result;

		}

        // GET: api/Adverts/5
        [ResponseType(typeof(Advert))]
        public async Task<IHttpActionResult> GetAdvert(int id)
        {
            Advert advert = await _advertRepository.GetAdvertByID(id);
            if (advert == null)
            {
                return NotFound();
            }
            return Ok(advert);
        }

		// PUT: api/Adverts/5
		[ValidateModelForNull(ActionModelParameterName = "advert")]
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

			_advertRepository.UpdateAdvert(advert);

			try
			{
				await _advertRepository.SaveAsync();
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

		[SkipIdValidation]
		[ValidateModelForNull(ActionModelParameterName = "advert")]
		[ResponseType(typeof(Advert))]
		public async Task<IHttpActionResult> PostAdvert(Advert advert)
        {

			if (!ModelState.IsValid)
			{
                return BadRequest(ModelState);
            }

			_advertRepository.InsertAdvert(advert);
			await _advertRepository.SaveAsync();

			return CreatedAtRoute("DefaultApi", new { id = advert.Id }, advert);
        }

        // DELETE: api/Adverts/5
        [ResponseType(typeof(Advert))]
        public async Task<IHttpActionResult> DeleteAdvert(int id)
        {
			Advert advert = await _advertRepository.GetAdvertByID(id);

			if (advert == null)
            {
                return NotFound();
            }

			_advertRepository.DeleteAdvert(id);
			await _advertRepository.SaveAsync();
			return Ok();
        }

        private bool AdvertExists(int id)
        {
			return _advertRepository.GetAdverts().Count(e => e.Id == id) > 0;
		}
    }
}