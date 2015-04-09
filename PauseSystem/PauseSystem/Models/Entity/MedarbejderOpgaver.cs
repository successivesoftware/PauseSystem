using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class MedarbejderOpgaver : BaseEntity
    {
        
        public string Navn { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public int EmployeeId { get; set; }
        public Nullable<bool> IsDone { get; set; }
        public Nullable<int> TaskId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
