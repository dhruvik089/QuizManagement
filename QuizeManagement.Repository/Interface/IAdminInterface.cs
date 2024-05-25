using QuizeManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Repository.Interface
{
    public interface IAdminInterface
    {
        QuizzesModel AddQuiz(QuizzesModel _quizzesModel);
        void AddQuestion(List<QustionAddingModel> _QustionAddingModel);
        List<QuizzesModel> GetQuizzes();
    }
}
