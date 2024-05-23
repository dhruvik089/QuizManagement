using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuizeManagement.Models.ViewModel
{
    public class LoginModel
    {
        
        [Required(ErrorMessage ="Enter Email ")]
        [RegularExpression(@"^[a-zA-Z0-9_.%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email id.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Enter Password")]
        public string Password { get; set; }
    }
}
