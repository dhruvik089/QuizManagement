using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace QuizeManagement.Models.ViewModel
{
    public class RegisterModel
    {
        [Key]
        public int Userid { get; set; }

        [Required(ErrorMessage ="enter Username")]
        [MaxLength(15,ErrorMessage ="Username must be 15 character")]
        [MinLength(4,ErrorMessage ="Username must be 4 character")]
        [RegularExpression(@"^[a-z]+[0-9]+$", ErrorMessage = "Invalid Username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "enter Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email id.")]

        public string Email{ get; set; }

        [Required(ErrorMessage ="Enter Password")]
        [MinLength(8, ErrorMessage = "Password must be 8 character")]
        public string Password{ get; set; }

        [Required(ErrorMessage ="Enter Confirm Password ")]
        [Compare("Password",ErrorMessage ="Password doesn't Metch")]
        public string ConfirmPassword{ get; set; }
    }
}
