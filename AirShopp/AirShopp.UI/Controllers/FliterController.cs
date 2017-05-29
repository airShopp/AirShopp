using AirShopp.Common;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class FliterController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session[Constants.SESSION_USER] == null && Session[Constants.SESSION_ADMIN] == null)
            {
                filterContext.Result = RedirectToAction("Login", "User");
            }
        }
    }
}