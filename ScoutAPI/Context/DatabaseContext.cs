using System.Data.Entity;
using ScoutAPI.Models;

namespace ScoutAPI.Context
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext() : base("DefaultConnection") { }

		public DbSet<Advert> Adverts { get; set; }

	}
}