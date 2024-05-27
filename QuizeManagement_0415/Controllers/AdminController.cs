using QuizeManagement.Helper.GenericRepository;
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
    public class AdminController : Controller
    {
        QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities();

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
            return RedirectToAction("Admin");
        }

        public ActionResult CreateQuestion(int id, string description, string title)
        {
            ViewBag.QuizId = id;
            ViewBag.titles = title;
            ViewBag.description = description;
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuestion(List<QustionAddingModel> _QustionAddingModel)

        {

            _admin.AddQuestion(_QustionAddingModel);

            return View();

        }

        public ActionResult Edit(int id)
        {
            Quizzes_Table _quizzes = _context.Quizzes_Table.Find(id);

            return View(_quizzes);
        }

        [HttpPost]
        public ActionResult Edit(Quizzes_Table _quizzes)
        {
            if (ModelState.IsValid)
            {
                _quizzes.Updated_at = DateTime.Now;
                _context.Entry(_quizzes).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(_quizzes);
        }

        public ActionResult UpdateQuestion(int id)
        {
            CustomQuizModel QuizzeModelList = GenericRepository.GetQuizWithQuestionsAndOptions(id);
            return View(QuizzeModelList);
        }

        [HttpPost]
        public ActionResult UpdateQuestion(CustomQuizModel _customQuizModel)

        {
            GenericRepository.UpdateQuizQuestionAndOptions(_customQuizModel);
            return Json(new { redirectUrl = Url.Action("Admin") });
        }

       

    }
}