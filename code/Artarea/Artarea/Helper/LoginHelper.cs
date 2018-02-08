using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artarea.Helper
{
    public class LoginHelper
    {
        //public static string SmtpServer = "";
        //public static string UserName = "";



        public static void LoggedInUser(User currentUser)
        {
            HttpContext.Current.Session["LoggedInUser"] = currentUser;
            isLoggedIn = true;
        }

        public static void LogOut()
        {
            HttpContext.Current.Session["LoggedInUser"] = null;
            isLoggedIn = false;
        }


        public static bool isLoggedIn;


        public static User currentUser()
        {
            return (User)HttpContext.Current.Session["LoggedInUser"];
        }
 

    }
}