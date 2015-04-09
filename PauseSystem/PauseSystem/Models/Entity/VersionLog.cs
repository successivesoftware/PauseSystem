using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class VersionLog : BaseEntity
    {
        
        public string Version { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Description { get; set; }
    }
}
