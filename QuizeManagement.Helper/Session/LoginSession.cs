using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QuizeManagement.Helper.Session
{

    public class LoginSession
    {
        private const string Email_SESSION_KEY = "Email";

        // Property to get/set the logged-in user
        public static string LoggedInUser
        {
            get { return HttpContext.Current.Session[Email_SESSION_KEY] as string; }
            set { HttpContext.Current.Session[Email_SESSION_KEY] = value; }
        }
        public static int GetUserId
        {
            get
            {
                return HttpContext.Current.Session["UserId"] == null ? 0 : (int)HttpContext.Current.Session["UserId"];
            }

            set
            {

                HttpContext.Current.Session["UserId"] = value;

            }

        }
        public static int GetAdminId
        {
            get
            {
                return HttpContext.Current.Session["AdminId"] == null ? 0 : (int)HttpContext.Current.Session["AdminId"];
            }

            set
            {

                HttpContext.Current.Session["AdminId"] = value;

            }

        }
        public static bool IsUserLoggedIn
        {
            get
            {
                if (HttpContext.Current.Session[Email_SESSION_KEY] == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        // Method to log out the user
        public static void LogOutUser()
        {
            HttpContext.Current.Session.Remove(Email_SESSION_KEY);
            HttpContext.Current.Session.Abandon();
        }
    }
}
