using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class ClosedDate : BaseEntity
    {
        
        public System.DateTime TimeClosed { get; set; }
        public int Year { get; set; }
        public int Week { get; set; }
        public int DayOfWeek { get; set; }
        public Nullable<System.DateTime> Dato { get; set; }
    }
}
