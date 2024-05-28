using QuizeManagement.Helper.GenericRepository;
using QuizeManagement.Helper.SpHelper;
using QuizeManagement.Models.ViewModel;
using QuizeManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Repository.Service
{
    public class AdminServices : IAdminInterface
    {
        public QuizzesModel AddQuiz(QuizzesModel _quizzesModel)
        {
            try
            {
                Dictionary<string, object> parameter = new Dictionary<string, object>
                {
                    {"@title",_quizzesModel.Title},
                    {"@description",_quizzesModel.Description}
                };
                QuizzesModel quizzesModel = GenericRepository.GenerateQuiz(SpHelper.CreateQuiz, parameter);
                return quizzesModel;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public List<QuizzesModel> GetQuizzes()
        {
            try
            {
                List<QuizzesModel> quizzesList = GenericRepository.GetQuizList(SpHelper.GetCreatedQuizList, null);
                return quizzesList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void AddQuestion(List<QustionAddingModel> _QustionAddingModel)
        {
            string AddQuestionsAndOptions = "AddQuestionsAndOptions";
            foreach (var item in _QustionAddingModel)
            {
                QustionAddingModel _QustionAddingModels = new QustionAddingModel();
                string Answers = item.Answers;
                string options1 = item.options1;
                string options2 = item.options2;
                string options3 = item.options3;
                string options4 = item.options4;
                string question = item.question;
                string quizId = item.quizId;
                int quizId_ = Convert.ToInt32(item.quizId);
                Dictionary<string, object> Parameters = new Dictionary<string, object>
                {
                    {"@quiz_id" ,quizId_},
                    {"@question_text ",question},
                    {"@options1 ", options1},
                    {"@options2 ",options2},
                    {"@options3", options3},
                    {"@options4", options4},
                    { "@Answers",Answers}
                };
                GenericRepository.AddQuestion(AddQuestionsAndOptions, Parameters);
            }

        }
        public void DeleteQuizFromDB(int QuizId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@QuizId" ,QuizId},
            };

            GenericRepository.DeleteQuizFromDB(SpHelper.DeleteQuize, parameters);
        }

    }
}
