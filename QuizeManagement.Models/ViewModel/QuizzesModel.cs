using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Models.ViewModel
{
    public class QuizzesModel
    {
        public int Quiz_id { get; set; }
        [Required (ErrorMessage ="Enter Title of Quiz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Enter Title of Quiz")]
        public string Description { get; set; }
        public Nullable<int> Created_by { get; set; }
        public Nullable<System.DateTime> Created_at { get; set; }
        public Nullable<System.DateTime> Updated_at { get; set; }
    }
}
