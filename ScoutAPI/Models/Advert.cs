using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScoutAPI.Models
{
	public class Advert
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public FuelEnum Fuel { get; set; }

		[Required]
		public int Price { get; set; }

		[Required]
		public bool IsNew { get; set; }

		// only for used cars
		[RequiredIfVehicleNotNew]
		public int Mileage { get; set; }

		// only for used cars
		[RequiredIfVehicleNotNew]
		[JsonConverter(typeof(OnlyDateConverter))]
		public DateTime? FirstRegistration { get; set; }

	}
}