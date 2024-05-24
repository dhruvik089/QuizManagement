using QuizeManagement.Models.ViewModel;
using QuizeManagement.Repository.Interface;
using QuizeManagement.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizeManagement_0415.Controllers
{
    public class AdminController : Controller
    {
        IAdminInterface _admin;

        public AdminController()
        {
            _admin = new AdminServices();
        }


        public ActionResult Admin()
        {
            List<QuizzesModel> quizzesList = _admin.GetQuizzes();
            return View(quizzesList);
        }
        public ActionResult Quiz()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Quiz(QuizzesModel _quizzesModel)
        {
            _admin.AddQuiz(_quizzesModel);
            return View();
        }

        public ActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuestion(List<QustionAddingModel> _QustionAddingModel)

        {

            _admin.AddQuestion(_QustionAddingModel);

            return View();

        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(QuizzesModel _quizzesModel)
        {
            return View();
        }
    }
}