using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Models.ViewModel
{
   public class QustionAddingModel
    {
        public string quizId { get; set; }
        public string question { get; set; }

        public string options1 { get; set; }

        public string options2 { get; set; }

        public string options3 { get; set; }

        public string options4 { get; set; }

        public string Answers { get; set; }
    }
}
