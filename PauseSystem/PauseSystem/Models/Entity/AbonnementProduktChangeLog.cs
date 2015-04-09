using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class AbonnementProduktChangeLog : BaseEntity
    {
        
        public int KundeId { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime PauseStart { get; set; }
        public System.DateTime PauseEnd { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Produkt { get; set; }
        public Nullable<int> Antal { get; set; }
        public Nullable<int> AbonnementProduktId { get; set; }
        public Nullable<System.DateTime> SentDate { get; set; }
        public Nullable<int> PauseId { get; set; }
    }
}
