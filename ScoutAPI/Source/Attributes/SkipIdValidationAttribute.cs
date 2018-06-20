using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ScoutAPI
{
	public class SkipIdValidationAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (actionContext.ModelState.IsValid == false)
			{
				foreach (string key in actionContext.ModelState.Keys.ToList())
				{
					if (key.ToUpper().Contains(".ID"))
					{
						actionContext.ModelState.Remove(key);
					}

				}

			}

		}
	}
}