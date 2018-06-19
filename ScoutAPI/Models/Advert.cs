using System;

namespace ScoutAPI.Models
{
	public class Advert
	{

		int Id { get; set; }
		string Title { get; set; }
		FuelEnum Fuel { get; set; }
		int Price { get; set; }
		bool isNew { get; set; }
		int Mileage { get; set; }
		DateTime FirstRegistration { get; set; }

	}
}