using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Models.ViewModel
{
    public class QuestionOptionViewModel
    {
        public QuizzesModel Quiz { get; set; } 
        public QuestionModel Question { get; set; }
        public List<OptionsModel> Options { get; set; }
    }
}
