using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtareaNew.Controllers
{
    public class BlogController : BaseController
    {
        // GET: Blog
        public ActionResult Blog()
        {
            return View();
        }
    }
}