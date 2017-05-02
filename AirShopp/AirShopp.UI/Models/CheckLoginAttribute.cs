using AirShopp.Common;
using System.Web.Mvc;

namespace AirShopp.UI.Models
{
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.Session == null || filterContext.HttpContext.Session[Constants.SESSION_USER] == null)
            {
                filterContext.HttpContext.Response.Redirect("/User/Login");
            }
        }
    }
}