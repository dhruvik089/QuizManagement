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
    }
}
