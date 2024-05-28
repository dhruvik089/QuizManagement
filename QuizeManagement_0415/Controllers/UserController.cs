using QuizeManagement.Helper.Helper;
using QuizeManagement.Helper.Session;
using QuizeManagement.Helpers.Helper;
using QuizeManagement.Models.DbContext;
using QuizeManagement.Models.ViewModel;
using QuizeManagement.Repository.Interface;
using QuizeManagement.Repository.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace QuizeManagement_0415.Controllers
{
    [CustomAutherize]

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
            Session["quizId"] = id;
            ViewBag.userId = Convert.ToInt32(Session["Userid"]);
            List<QuestionModel> questionList = _user.GetQuestionForQuiz(id);
            ViewBag.questionList = questionList;
            Session["questionId"] = _user.GetQuestionId(id);
            ViewBag.questionId = _user.GetQuestionId(id);

            return View();
        }

        public ActionResult ConfirmStartQuiz(int quetionid)
        {
            ViewBag.questionId = quetionid;
            ViewBag.Questions = _user.GetQuestionById(quetionid);
            List<OptionsModel> optionList = _user.GetOptionForQuestion(quetionid);
            return PartialView("_PartialQuestion",optionList);  
        }

   

        public JsonResult AddUserAnswers(UserAnswerModel _UserAnswer)
        {
            _UserAnswer.User_id= Convert.ToInt32(Session["Userid"]);
            _UserAnswer.Quiz_id= Convert.ToInt32(Session["quizId"]);

            int isAnswers = _user.SaveUserAnswer(_UserAnswer);
            return Json(isAnswers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Result() 
        {
            int UserId= Convert.ToInt32(Session["Userid"]);
            int QuizId= Convert.ToInt32(Session["quizId"]);

            int QuizResultTotalMarks = _user.ResultOfQuizForUser(UserId, QuizId);

            ViewBag.QuizResultTotalMarks = QuizResultTotalMarks;
            return View();
        }

        public ActionResult LogOut()
        {
            LoginSession.LogOutUser();
            return RedirectToAction("Login", "Login");
        }

    }
}