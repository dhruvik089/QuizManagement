using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizeManagement_0415.Session
{
    public class LoginSession
    {
        public static string isLogin
        {
            get
            {
                return HttpContext.Current.Session["Email"] == null ? "" : (string)HttpContext.Current.Session["Email"];
            }
            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }

        public static bool isUserLogged()
        {
            if(HttpContext.Current.Session["Email"] != null)
            {
                return true;
            }
            return false;
        }

        public static void LogOut()
        {
            HttpContext.Current.Session.Abandon();
        }

    }
}