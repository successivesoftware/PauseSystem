using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class AbonnementProduktChange : BaseEntity
    {
        
        public int AbonnementProduktId { get; set; }
        public int Antal { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int MadeById { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> ProduktNumber { get; set; }
    }
}
