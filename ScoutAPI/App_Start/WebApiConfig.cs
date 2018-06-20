using Newtonsoft.Json.Serialization;
using ScoutAPI.DAL;
using System.Web.Http;
using Unity;

namespace ScoutAPI
{
	public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			config.EnableCors();

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			RegisterDependencies(config);
			RegisterJsonFormatter(config);

		}

		private static void RegisterJsonFormatter(HttpConfiguration config)
		{
			// JSON formatter
			config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
			config.Formatters.JsonFormatter.SerializerSettings.Formatting =
				Newtonsoft.Json.Formatting.Indented;
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
				new CamelCasePropertyNamesContractResolver();
		}

		private static void RegisterDependencies(HttpConfiguration config)
		{
			var unityContainer = new UnityContainer();
			unityContainer.RegisterType<IAdvertRepository, AdvertRepository>();
			config.DependencyResolver = new UnityResolver(unityContainer);

		}
	}
}
