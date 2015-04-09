using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Pri : BaseEntity
    {
        public int ProduktNr { get; set; }
        public Nullable<double> SalgsPris { get; set; }
        public int KundeId { get; set; }
        
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> MedarbejderId { get; set; }
        public Nullable<bool> Aktiv { get; set; }
    }
}
