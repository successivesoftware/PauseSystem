using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class ProduktGrupper : BaseEntity
    {
        
        public string Navn { get; set; }
        public Nullable<bool> PakkelistePrintesAlene { get; set; }
        public Nullable<bool> ListerPrintesSammenForDage { get; set; }
        public int MaxPrDelivery { get; set; }
    }
}
