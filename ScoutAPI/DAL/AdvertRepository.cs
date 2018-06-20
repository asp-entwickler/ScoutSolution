using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ScoutAPI.Context;
using ScoutAPI.Models;

namespace ScoutAPI.DAL
{
	public class AdvertRepository : IAdvertRepository, IDisposable
	{

		private DatabaseContext context;

		public AdvertRepository(DatabaseContext context)
		{
			this.context = context;
		}

		public IEnumerable<Advert> GetAdverts()
		{
			return context.Adverts.ToList();
		}

		public async Task<Advert> GetAdvertByID(int id)
		{
			return await context.Adverts.FindAsync(id);
		}

		public void InsertAdvert(Advert advert)
		{
			context.Adverts.Add(advert);
		}

		public void DeleteAdvert(int advertID)
		{
			Advert advert = context.Adverts.Find(advertID);
			context.Adverts.Remove(advert);
		}

		public void UpdateAdvert(Advert advert)
		{
			context.Entry(advert).State = EntityState.Modified;
		}

		public async Task SaveAsync()
		{
			await context.SaveChangesAsync();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}




}
