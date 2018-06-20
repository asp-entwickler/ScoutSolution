using ScoutAPI.Models;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ScoutAPI
{
	public class CheckFieldsForUsedCarsAttribute : ActionFilterAttribute
	{

		public string ActionModelParameterName { get; set; }

		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (actionContext.ModelState.IsValid)
			{

				var advertModel = (Advert)actionContext.ActionArguments[ActionModelParameterName];

				if (!advertModel.IsNew)
				{
					if (advertModel.Mileage == 0)
						actionContext.ModelState.AddModelError(string.Empty, "If car not new Mileage requred");

					if (advertModel.FirstRegistration == null)
						actionContext.ModelState.AddModelError(string.Empty, "If car not new Registration Date requred");

				}

			}

		}

	}

}