using QuizeManagement.Models.DbContext;
using QuizeManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Helper.Helper
{
    public class RegistrationHelper
    {
        public static User_Table ConvertModelToContex(UserModel _userModel)
        {
            User_Table _UserTable = new User_Table();

            _UserTable.Username = _userModel.Username;
            _UserTable.Email = _userModel.Email;
            _UserTable.Password_hash = _userModel.Password_hash;

            return _UserTable;
        }
    }
}
