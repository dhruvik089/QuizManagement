using QuizeManagement.Helper.GenericRepository;
using QuizeManagement.Helper.SpHelper;
using QuizeManagement.Models.DbContext;
using QuizeManagement.Models.ViewModel;
using QuizeManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            string password = _registerModel.Password;
            string Email = _registerModel.Email;


            Dictionary<string, object> _addUser = new Dictionary<string, object>
                {
                            { "@Username", Username},
                            { "@password", password },
                            { "@Email", Email }
                };
            Dictionary<string, object> _checkUser = new Dictionary<string, object>
                {

                            { "@Password_hash", password },
                            { "@Email", Email }
                };
            DataTable dataTable = GenericRepository.GetSingleDataTable(SpHelper.CheckRegisterLogin, _checkUser);
            if (dataTable == null)
            {
                GenericRepository.GetSingleDataTable(SpHelper.AddUser, _addUser);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckUser(LoginModel _loginModel)
        {
            try
            {
                Dictionary<string, object> parameter = new Dictionary<string, object>
                {
                    {"@Password_hash",_loginModel.Password },
                    {"@Email",_loginModel.Email }
                };
                DataTable dataTable = GenericRepository.GetSingleDataTable(SpHelper.CheckRegisterLogin, parameter);
                if (dataTable != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
