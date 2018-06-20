using ScoutAPI.Models;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ScoutAPI
{
	public class ValidateModelForNullAttribute : ActionFilterAttribute
	{

		public string ActionModelParameterName { get; set; }

		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (actionContext.ModelState.IsValid)
			{

				var advertModel = (Advert)actionContext.ActionArguments[ActionModelParameterName];
				if (advertModel == null)
				{
					actionContext.ModelState.AddModelError(string.Empty, "Model can not be null");
				}
			}
		}
	}

}
