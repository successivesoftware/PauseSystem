using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class LeveringsChange : BaseEntity
    {
        
        public int Antal { get; set; }
        public System.DateTime Date { get; set; }
        public int MadeById { get; set; }
        public int ProduktNumber { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
