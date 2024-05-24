﻿using QuizeManagement.Models.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Models.ViewModel
{
    public class UserAnswerModel
    {

        public int Answer_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public Nullable<int> Quiz_id { get; set; }
        public Nullable<int> Question_id { get; set; }
        public Nullable<int> Selected_Option_id { get; set; }
        public Nullable<System.DateTime> Created_at { get; set; }

        public virtual Options_Table Options_Table { get; set; }
        public virtual Question_Table Question_Table { get; set; }
        public virtual Quizzes_Table Quizzes_Table { get; set; }
        public virtual User_Table User_Table { get; set; }
    }
}
