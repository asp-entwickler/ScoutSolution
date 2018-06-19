using ScoutAPI.Models;
using System;
using System.Data.Entity;

namespace ScoutAPI.Context
{
	public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
	{
		protected override void Seed(DatabaseContext context)
		{

			base.Seed(context);

			context.Adverts.Add(
				new Advert {
					Id = 1,	Title = "BMW 525", Fuel = FuelEnum.Gasoline, Price = 15000, IsNew = true
				});
			context.Adverts.Add(
				new Advert {
					Id = 2, Title = "Honda CR-V", Fuel = FuelEnum.Gasoline, Price = 27500, IsNew = true
				});
			context.Adverts.Add(
				new Advert {
					Id = 3, Title = "Dodge Challenger", Fuel = FuelEnum.Diesel, Price = 65400, IsNew = false,
					Mileage = 79000, FirstRegistration = new DateTime(2011, 04, 21)
				});
			context.Adverts.Add(
				new Advert {
					Id = 4, Title = "Ford F-150", Fuel = FuelEnum.Diesel, Price = 54000, IsNew = false,
					Mileage = 214000, FirstRegistration = new DateTime(2007, 11, 04)
				});
			context.Adverts.Add(
				new Advert {
					Id = 5, Title = "Toyota Camry", Fuel = FuelEnum.Gasoline, Price = 18200, IsNew = false,
					Mileage = 347000, FirstRegistration = new DateTime(2003, 06, 17)
				});

			context.SaveChanges();

		}
	}
}