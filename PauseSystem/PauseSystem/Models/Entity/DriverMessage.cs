using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class DriverMessage : BaseEntity
    {
        
        public string Text { get; set; }
        public Nullable<int> PostedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ReadBy { get; set; }
        public Nullable<System.DateTime> ReadAt { get; set; }
        public Nullable<bool> IsRead { get; set; }
    }
}
