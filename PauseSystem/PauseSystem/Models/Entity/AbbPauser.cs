using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class AbbPauser : BaseEntity
    {
        public int AbonnementId { get; set; }
        
        public System.DateTime Start { get; set; }
        public System.DateTime Slut { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> EmployeeId { get; set; }
    }
}
