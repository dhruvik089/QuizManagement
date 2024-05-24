using QuizeManagement.Models.ViewModel;
using QuizeManagement.Repository.Interface;
using QuizeManagement.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QuizeManagement_0415.Controllers
{
    public class LoginController : Controller
    {
        IUserInterface _user;

        public LoginController()
        {
            _user = new UserService();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel _registerModel)
        {
            if (ModelState.IsValid)
            {
                if (_user.AddUser(_registerModel))
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Email", "Email already exist");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel _loginModel)
        {
            if (ModelState.IsValid)
            {
                AdminModel _adminModel = _user.CheckAdmin(_loginModel);
                RegisterModel _registerModel = _user.CheckUser(_loginModel);

                if (_registerModel.Userid > 0 && _adminModel.Username == null)
                {
                    Session["Username"] = _registerModel.Username;
                    Session["Userid"] = _registerModel.Userid.ToString();
                    return RedirectToAction("User", "User");
                }
                else if (_registerModel.Username == null && _adminModel.Admin_id > 0)
                {
                    Session["Username"] = _registerModel.Username;
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    ModelState.AddModelError("Password", "Enter valid email or password");
                    return View("Login");
                }
            }
            else
            {
                return View();
            }
        }


    }
}