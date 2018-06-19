using ScoutAPI.Context;
using System.Web.Http;

namespace ScoutAPI
{
	public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

			System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());

		}
    }
}
