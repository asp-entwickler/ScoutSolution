using ScoutAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScoutAPI.DAL
{
	public interface IAdvertRepository : IDisposable
	{

        IEnumerable<Advert> GetAdverts();
		Task<Advert> GetAdvertByID(int advertId);
        void InsertAdvert(Advert advert);
        void DeleteAdvert(int advertID);
        void UpdateAdvert(Advert advert);
		Task SaveAsync();

	}
}
