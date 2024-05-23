//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuizeManagement.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_Table()
        {
            this.Quizzes_Table = new HashSet<Quizzes_Table>();
            this.Result_Table = new HashSet<Result_Table>();
            this.User_Answer_Table = new HashSet<User_Answer_Table>();
        }
    
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password_hash { get; set; }
        public Nullable<System.DateTime> Created_at { get; set; }
        public Nullable<System.DateTime> Updated_at { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quizzes_Table> Quizzes_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result_Table> Result_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Answer_Table> User_Answer_Table { get; set; }
    }
}
