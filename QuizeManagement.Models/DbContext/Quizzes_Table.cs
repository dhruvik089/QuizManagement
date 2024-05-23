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
    
    public partial class Quizzes_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quizzes_Table()
        {
            this.Question_Table = new HashSet<Question_Table>();
            this.Result_Table = new HashSet<Result_Table>();
            this.User_Answer_Table = new HashSet<User_Answer_Table>();
        }
    
        public int Quiz_id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> Created_by { get; set; }
        public Nullable<System.DateTime> Created_at { get; set; }
        public Nullable<System.DateTime> Updated_at { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question_Table> Question_Table { get; set; }
        public virtual User_Table User_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result_Table> Result_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Answer_Table> User_Answer_Table { get; set; }
    }
}