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
    
    public partial class Question_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question_Table()
        {
            this.Options_Table = new HashSet<Options_Table>();
            this.User_Answer_Table = new HashSet<User_Answer_Table>();
        }
    
        public int Question_id { get; set; }
        public Nullable<int> Quiz_id { get; set; }
        public string Question_txt { get; set; }
        public Nullable<System.DateTime> Created_at { get; set; }
        public Nullable<System.DateTime> Updated_at { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Options_Table> Options_Table { get; set; }
        public virtual Quizzes_Table Quizzes_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Answer_Table> User_Answer_Table { get; set; }
    }
}