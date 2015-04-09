using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class ComputerSetting : BaseEntity
    {
        
        public string ComputerName { get; set; }
        public int LabelprinterId { get; set; }
    }
}
