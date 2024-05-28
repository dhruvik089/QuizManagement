using QuizeManagement.Models.DbContext;
using QuizeManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Helper.Helper
{
    public class UserHelper
    {
        public static User_Table convertRegisterDemoModelToRegisterDemo(RegisterModel user)
        {
            User_Table _registerDemoModel = new User_Table();

            _registerDemoModel.User_id = user.Userid;
            _registerDemoModel.Username = user.Username;
            _registerDemoModel.Email = user.Email;
            _registerDemoModel.Password_hash = user.Password;

            return _registerDemoModel;
        }
        public static Admin convertRegisterModelToRegister(RegisterModel user)
        {
            Admin _registerDemoModel = new Admin();

            _registerDemoModel.Admin_id = user.Userid;
            _registerDemoModel.Username = user.Username;
            _registerDemoModel.Email = user.Email;
            _registerDemoModel.Password = user.Password;

            return _registerDemoModel;
        }

    }
}
