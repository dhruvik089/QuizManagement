using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Models.ViewModel
{
    public class OptionsModel
    {

        public int Option_id { get; set; }
        public Nullable<int> Question_id { get; set; }
        public string Option_text { get; set; }
        public Nullable<bool> Is_correct { get; set; }
        public Nullable<System.DateTime> Created_at { get; set; }
        public Nullable<System.DateTime> Updated_at { get; set; }

    }
}
