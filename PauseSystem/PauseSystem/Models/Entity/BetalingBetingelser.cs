using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class BetalingBetingelser : BaseEntity
    {
        
        public Nullable<int> StdRegValue { get; set; }
        public string Text { get; set; }
    }
}
