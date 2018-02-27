using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtareaNew.Models;

namespace ArtareaNew.Helper
{
    public class LoginHelper
    {


        public static void LoggedInUser(Admin currentUser)
        {
            HttpContext.Current.Session["LoggedInUser"] = currentUser;
            isLoggedIn = true;
        }


        public static void Logout()
        {
            HttpContext.Current.Session["LoggedInUser"] = null;
            isLoggedIn = false;
        }


        public static bool isLoggedIn;


        public static Admin currentUser()
        {
            return (Admin)HttpContext.Current.Session["LoggedInUser"];
        }

      
    }
}