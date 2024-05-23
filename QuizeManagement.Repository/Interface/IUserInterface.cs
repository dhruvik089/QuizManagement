﻿using QuizeManagement.Models.ViewModel;
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
        bool CheckUser(LoginModel _loginModel);
    }
}
