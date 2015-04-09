using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class GrøntKasseLeveringer : BaseEntity
    {
        
        public int Week { get; set; }
        public int Year { get; set; }
        public int AdressId { get; set; }
        public int RuteId { get; set; }
        public string Leveringer { get; set; }
        public Nullable<int> ProduktId { get; set; }
    }
}
