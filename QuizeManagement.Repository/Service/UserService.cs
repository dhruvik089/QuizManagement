﻿using QuizeManagement.Helper.GenericRepository;
using QuizeManagement.Helper.SpHelper;
using QuizeManagement.Models.DbContext;
using QuizeManagement.Models.ViewModel;
using QuizeManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Repository.Service
{
    public class UserService : IUserInterface
    {
        QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities();
        public bool AddUser(RegisterModel _registerModel)
        {

            string Username = _registerModel.Username;
            string password = HashPassword(_registerModel.Password);
            string Email = _registerModel.Email;


            Dictionary<string, object> _addUser = new Dictionary<string, object>
                {
                            { "@Username", Username},
                            { "@password", password },
                            { "@Email", Email }
                };
            Dictionary<string, object> _checkUser = new Dictionary<string, object>
                {
                            { "@Email", Email }
                };
            bool IsEmailExist = GenericRepository.IsEmailExist(SpHelper.CheckingEmailExistsOrNot, _checkUser);

            if (IsEmailExist)
            {
                GenericRepository.GetSingleDataTable(SpHelper.AddUser, _addUser);
                return true;
            }
            else
            {
                return false;
            }

        }

        public AdminModel CheckAdmin(LoginModel _loginModel)
        {
            try
            {
                Dictionary<string, object> parameter = new Dictionary<string, object>
                {
                    {"@Password",_loginModel.Password},
                    {"@Email",_loginModel.Email }
                };
                AdminModel _adminModel = GenericRepository.CheckingAdminLogin(SpHelper.AdminLogin, parameter);

                return _adminModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public RegisterModel CheckUser(LoginModel _loginModel)
        {
            string encyPasswd = HashPassword(_loginModel.Password);
            try
            {

                Dictionary<string, object> parameter = new Dictionary<string, object>
                {
                    {"@Password_hash",encyPasswd},
                    {"@Email",_loginModel.Email }
                };
                RegisterModel _registerModel = GenericRepository.CheckingUserIsValidOrNotLogin(SpHelper.CheckRegisterLogin, parameter);

                return _registerModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string getUserName(LoginModel _loginModel)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>
                {
                    {"@Password_hash",_loginModel.Password },
                    {"@Email",_loginModel.Email }
                };
            string UserName = GenericRepository.getUserName(SpHelper.getUser, parameter);

            return UserName;

        }

        public UserModel getUserDetails(int id)
        {

            Dictionary<string, object> parameter = new Dictionary<string, object>
                {
                    {"@id",id }
                };

            UserModel _userModel = GenericRepository.GetUserDetails(SpHelper.getUserDetails, parameter);
            return _userModel;
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

        public List<QuestionModel> GetQuestionForQuiz(int quizId)
        {


            Dictionary<string, object> perameter = new Dictionary<string, object>
            {
                {  "@QuizId" ,quizId }
            };

            List<QuestionModel> _customQuizModelList = GenericRepository.getQuestionByQuizId(SpHelper.getQuestionByQuizId, perameter).ToList();

            return _customQuizModelList;
        }

        public List<OptionsModel> GetOptionForQuestion(int questionId)
        {


            Dictionary<string, object> perameter = new Dictionary<string, object>
            {
                {  "@question_Id" ,questionId }
            };

            List<OptionsModel> _customQuizModelList = GenericRepository.GetOptionForQuestion(SpHelper.getOptionByQuestionId, perameter).ToList();

            return _customQuizModelList;
        }

      
    }
}
