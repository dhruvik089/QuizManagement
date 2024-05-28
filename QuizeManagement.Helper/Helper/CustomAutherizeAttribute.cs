using QuizeManagement.Helper.Helper;
using QuizeManagement.Helper.Session;
using QuizeManagement.Models.DbContext;
using QuizeManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuizeManagement.Helpers.Helper
{
    public class CustomAutherizeAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            QuizeManagement_0415Entities _option = new QuizeManagement_0415Entities();
            RegisterModel db = new RegisterModel();

            User_Table _RegistersUserUsername = UserHelper.convertRegisterDemoModelToRegisterDemo(db);
            _RegistersUserUsername = _option.User_Table.FirstOrDefault(m => m.Email == LoginSession.LoggedInUser);


            if (_RegistersUserUsername != null)
            {
                return LoginSession.IsUserLoggedIn;
            }

            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!LoginSession.IsUserLoggedIn)
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
            }
            else
            {     // Not Direct Acess Home/Index Using This Methods

                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }
    }
}