using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Models.ViewModel
{
    public class QuestionModel
    {
        public int Question_id { get; set; }
        public Nullable<int> Quiz_id { get; set; }
        public string Question_txt { get; set; }
        public Nullable<System.DateTime> Created_at { get; set; }
        public Nullable<System.DateTime> Updated_at { get; set; }
    }
}
