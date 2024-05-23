using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Models.ViewModel
{
   public class UserModel
    {
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password_hash { get; set; }
        public Nullable<System.DateTime> Created_at { get; set; }
        public Nullable<System.DateTime> Updated_at { get; set; }
    }
}
