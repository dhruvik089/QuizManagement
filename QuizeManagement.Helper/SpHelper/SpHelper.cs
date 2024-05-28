using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace QuizeManagement.Helper.SpHelper
{
    public class SpHelper
    {
        public const string AddUser = "AddUser";
        public const string CheckRegisterLogin = "CheckRegisterLogin";
        public const string CheckingEmailExistsOrNot = "CheckingEmailExistsOrNot";
        public const string getUser = "getUser";
        public const string AdminLogin = "AdminLogin";
        public const string getUserDetails = "getUserDetails";
        public const string GetCreatedQuizList = "GetCreatedQuizList";
        public const string CreateQuiz = "CreateQuiz";
        public const string getQuestionByQuizId = "getQuestionByQuizId";
        public const string getOptionByQuestionId = "getOptionByQuestionId";
        public const string GetQuestionID = "GetQuestionID";
        public const string getQuestionById = "getQuestionById";
        public const string DeleteQuize = "DeleteQuize";
        public const string ShowResult = "ShowResult";
        public const string SaveUserAnswer = "SaveUserAnswer";
        public const string ShowQuizResult = "ShowQuizResult";
    }
}
