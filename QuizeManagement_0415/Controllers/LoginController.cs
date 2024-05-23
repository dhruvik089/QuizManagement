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
                Session["pass"] = HashPassword(_registerModel.Password);
                _user.AddUser(_registerModel);
                return RedirectToAction("Login");
            }
            else { return View(); }
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
                string encyPasswd = HashPassword(_loginModel.Password);
                _loginModel.Password = encyPasswd;

                if (_user.CheckUser(_loginModel))
                {
                    return RedirectToAction("Register");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View();
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                if (password != null)
                {
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    return Convert.ToBase64String(hashedBytes);

                }
                return null;
            }
        }
    }
}