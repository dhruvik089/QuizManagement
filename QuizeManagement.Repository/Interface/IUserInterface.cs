using QuizeManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Repository.Interface
{
    public interface IUserInterface
    {
        bool AddUser(RegisterModel _registerModel);
        RegisterModel CheckUser(LoginModel _loginModel);
        AdminModel CheckAdmin(LoginModel _loginModel);
        string getUserName(LoginModel _loginModel);
        UserModel getUserDetails(int id);
        List<QuestionModel> GetQuestionForQuiz(int quizId);
        List<OptionsModel> GetOptionForQuestion(int questionId);
    }
}
