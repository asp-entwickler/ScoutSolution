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

		public int Mileage { get; set; }

		//[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime? FirstRegistration { get; set; }

	}
}