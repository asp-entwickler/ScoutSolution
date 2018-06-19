using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;


namespace ScoutAPI.Source
{
	//public class ValidateModelStateAttribute : ActionFilterAttribute
	//{
	//public override void OnActionExecuting(HttpActionContext actionContext)
	//{
	//if (!actionContext.ModelState.IsValid)
	//{
	//	//actionContext.Response = actionContext.Request.CreateErrorResponse(
	//	actionContext.Response = actionContext.Request
	//		.  .CreateResponse(
	//	HttpStatusCode.BadRequest, actionContext.ModelState);

	//	//HttpRequestMessage request = new HttpRequestMessage();
	//	//var response = request.CreateResponse(HttpStatusCode.OK, customer);

	//}


	//public override void OnActionExecuting(HttpActionContext actionContext)
	//{
	//	actionContext.Response = actionContext.Request.CreateResponse(
	//		HttpStatusCode.OK,
	//		actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
	//	);
	//}




	public class ValidateModelStateAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (!actionContext.ModelState.IsValid)
			{
				actionContext.Response = actionContext.Request.CreateErrorResponse(
					HttpStatusCode.BadRequest, actionContext.ModelState);
			}
		}
	}



	//}
}