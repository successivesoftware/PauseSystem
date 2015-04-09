using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Week : BaseEntity
    {
        public Nullable<int> WeekNr { get; set; }
        public Nullable<int> Year { get; set; }
        public byte[] Ture { get; set; }
        public byte[] Ændringer { get; set; }
        public byte[] IkkeTilføjet { get; set; }
        public byte[] FrugtDK { get; set; }
        public byte[] Undtagelser { get; set; }
        public byte[] Ydelser { get; set; }
        
    }
}
