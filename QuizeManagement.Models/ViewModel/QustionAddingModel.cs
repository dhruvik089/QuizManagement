using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Models.ViewModel
{
    public class QustionAddingModel
    {
        public string quizId { get; set; }

        [Required(ErrorMessage = "Enter Question...")]
        public string question { get; set; }

        [Required(ErrorMessage = "Enter Option 1...")]
        public string options1 { get; set; }

        [Required(ErrorMessage = "Enter Option 2...")]
        public string options2 { get; set; }

        [Required(ErrorMessage = "Enter Option 3...")]
        public string options3 { get; set; }

        [Required(ErrorMessage = "Enter Option 4...")]
        public string options4 { get; set; }

        [Required(ErrorMessage = "Please select Correct Answer")]
        public string Answers { get; set; }
    }
}
