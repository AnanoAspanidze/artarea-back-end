﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtareaNew.Controllers
{
    public class ProgramController : Controller
    {
        // GET: Program
        public ActionResult Programs()
        {
            return View();
        }

        public ActionResult ProgramDetails()
        {
            return View();
        }

        public ActionResult Episode()
        {
            return View();
        }
    }
}