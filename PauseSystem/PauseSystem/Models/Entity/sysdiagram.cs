using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class sysdiagram : BaseEntity
    {
        public string name { get; set; }
        public int principal_id { get; set; }
        public int diagram_id { get; set; }
        public Nullable<int> version { get; set; }
        public byte[] definition { get; set; }
    }
}
