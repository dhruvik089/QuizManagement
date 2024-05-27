using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Models.ViewModel
{
    public class CustomQuizModel
    {
        public int Quiz_id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CustomQuestionModel> Questions { get; set; }

    }
    public class CustomQuestionModel
    {
        public int Question_id { get; set; }
        public int Quiz_id { get; set; }
        public string Question_txt { get; set; }
        public List<CustomOptionModel> Options { get; set; }
    }
    public class CustomOptionModel
    {
        public int option_id { get; set; }
        public int Question_id { get; set; }
        public string Option_text { get; set; }
        public bool Is_correct { get; set; }
    }
}
