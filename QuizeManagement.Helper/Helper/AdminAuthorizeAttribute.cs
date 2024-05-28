using QuizeManagement.Models.DbContext;
using QuizeManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using QuizeManagement.Helper.Session;
using QuizeManagement.Helper.Helper;

namespace QuizeManagement.Helpers.Helper
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            QuizeManagement_0415Entities _option = new QuizeManagement_0415Entities();
            RegisterModel db = new RegisterModel();

            Admin _RegistersUserUsername = UserHelper.convertRegisterModelToRegister(db);
            _RegistersUserUsername = _option.Admin.FirstOrDefault(m => m.Email == LoginSession.LoggedInUser);


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