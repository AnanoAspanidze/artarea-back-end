using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ArtareaNew.Controllers
{
    public class BaseController : Controller
    {
       
        protected string Language { get; set; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            if (filterContext.RouteData.Values.ContainsKey("Language"))
                Language = filterContext.RouteData.Values["Language"].ToString().ToLower();
            else
                Language = "ka-ge";

            ViewBag.language = Language;


            Thread.CurrentThread.CurrentCulture = new CultureInfo(Language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Language);
        }





    }
}