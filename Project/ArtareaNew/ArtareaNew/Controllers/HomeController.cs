using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtareaNew.Models;


namespace ArtareaNew.Controllers
{
    public class HomeController : BaseController
    {

 

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Live()
        {
            return View();
        }

    }
}