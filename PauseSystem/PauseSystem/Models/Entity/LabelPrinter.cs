using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class LabelPrinter : BaseEntity
    {
        
        public string Ip { get; set; }
        public Nullable<int> Port { get; set; }
        public string Name { get; set; }
    }
}
