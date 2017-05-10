/*
using ProgramWeb.Utilities;
using System;
using System.Web.Mvc;


namespace ErroProject.Custom
{
	public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //Get the exception
            Exception ex = filterContext.Exception;

            //TODO: Log the exception!
            //Example using singleton logger class in Utilities folder which write exception to file
            Logger.Instance.LogException(ex);

            //Set the view name to be returned, maybe return different error view for different exception types
            string viewName = "Error";

            //Get current controller and action
            string currentController = (string)filterContext.RouteData.Values["controller"];
            string currentActionName = (string)filterContext.RouteData.Values["action"];
            if (ex is CustomApplicationException)
            {
                viewName = "ErrorCustom";
            }
            if (ex is ArgumentException)
            {
                viewName = "ErrorArgument";
            }

			if (!(currentController == "Book" && currentActionName == "Index") && !(currentController == "Movie" && currentActionName == "Index"))
			{
				viewName = "Error";
			}

            //Create the error model information
            HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, currentController, currentActionName);
            ViewResult result = new ViewResult
            {
                ViewName = viewName,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };

            filterContext.Result = result;
            filterContext.ExceptionHandled = true;

            // Call the base class implementation:
            base.OnException(filterContext);
        }
    }
}
*/