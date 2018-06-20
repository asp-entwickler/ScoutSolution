using Newtonsoft.Json.Converters;

namespace ScoutAPI
{
	public class OnlyDateConverter : IsoDateTimeConverter
	{
		public OnlyDateConverter()
		{
			DateTimeFormat = "yyyy-MM-dd";
		}
	}

}