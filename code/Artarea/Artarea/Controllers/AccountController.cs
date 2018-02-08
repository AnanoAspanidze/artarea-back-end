using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Artarea.Models;

namespace Artarea.Controllers
{
    public class AccountController : Controller
    {

        ArtareaEntities _db = new ArtareaEntities();


        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

      
    }
}