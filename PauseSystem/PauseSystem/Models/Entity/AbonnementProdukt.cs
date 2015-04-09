using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class AbonnementProdukt : BaseEntity
    {
        
        public Nullable<int> AbonnementId { get; set; }
        public Nullable<int> ProduktNr { get; set; }
        public Nullable<System.DateTime> StartDato { get; set; }
        public Nullable<System.DateTime> SlutDato { get; set; }
        public Nullable<int> Antal { get; set; }
        public Nullable<int> Interval { get; set; }
        public Nullable<int> Ophør { get; set; }
        public string PrintLabel { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
