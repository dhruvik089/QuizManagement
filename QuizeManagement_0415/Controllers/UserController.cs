using QuizeManagement.Models.DbContext;
using QuizeManagement.Models.ViewModel;
using QuizeManagement.Repository.Interface;
using QuizeManagement.Repository.Service;
using QuizeManagement_0415.Session;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace QuizeManagement_0415.Controllers
{
    public class UserController : Controller
    {
        QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities();
        IUserInterface _user;
        IAdminInterface _admin;

        public UserController()
        {
            _user = new UserService();
            _admin = new AdminServices();
        }

        public ActionResult User()
        {
            List<QuizzesModel> quizzesList = _admin.GetQuizzes();
            return View(quizzesList);
        }
        public ActionResult Profile()
        {

            ViewBag.userDetails = _user.getUserDetails(Convert.ToInt32(Session["Userid"]));

            return View(ViewBag.userDetails);
        }


        public ActionResult Update()
        {
            User_Table _userDetails = _context.User_Table.Find(Convert.ToInt32(Session["Userid"]));

            return View(_userDetails);
        }

        [HttpPost]
        public ActionResult Update(User_Table user_Table)
        {
            if (ModelState.IsValid)
            {
                user_Table.Updated_at = DateTime.Now;
                _context.Entry(user_Table).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Profile");
            }
            return View(user_Table);
        }

        public ActionResult StartQuiz(int id)
        {
            ViewBag.quizID = id;
            List<QuestionModel> questionList = _user.GetQuestionForQuiz(id);
            ViewBag.questionId = questionList;

            return View();
        }

        public ActionResult ConfirmStartQuiz(int id)
        {
            return PartialView("_PartialQuestion");
        }

        public ActionResult LogOut()
        {
            LoginSession.LogOut();
            return RedirectToAction("Login", "Login");
        }

    }
}