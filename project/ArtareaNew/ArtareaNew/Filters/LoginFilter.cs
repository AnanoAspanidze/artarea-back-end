using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtareaNew.Models;
using System.Web.Routing;
namespace ArtareaNew.Filters
{
    public class LoginFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Admin US = (Admin)filterContext.HttpContext.Session["LogedUser"];
            if (US != null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller","Home"} ,
                        { "Account","Login"}
                    });
            }

            base.OnActionExecuting(filterContext);
        }

    }
}